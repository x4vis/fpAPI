DROP DATABASE IF EXISTS inv_cont;
CREATE DATABASE IF NOT EXISTS inv_cont DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE inv_cont;

-- HUMAN RESOURCES

CREATE TABLE IF NOT EXISTS Role (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(64) NOT NULL,
  mask TINYINT UNSIGNED NOT NULL
);

CREATE TABLE IF NOT EXISTS Office (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(128) NOT NULL,
  creation_date DATETIME DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS User (
 id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
 role_fk INT UNSIGNED NOT NULL,
 office_fk INT UNSIGNED NOT NULL,
 first_names VARCHAR(255) NOT NULL,
 last_names VARCHAR(255) NOT NULL,
 email VARCHAR(128) NOT NULL UNIQUE,
 phone_number VARCHAR(32) DEFAULT NULL,
 street VARCHAR(255) DEFAULT NULL,
 ext_num VARCHAR(32) DEFAULT NULL,
 int_num VARCHAR(32) DEFAULT NULL,
 neighborhood VARCHAR(64) DEFAULT NULL,
 cp MEDIUMINT UNSIGNED DEFAULT NULL,
 psw TINYBLOB NOT NULL,
 creation_date DATETIME DEFAULT NOW(),

 CONSTRAINT user_rol_fk FOREIGN KEY (role_fk) REFERENCES Role(id),
 CONSTRAINT user_office_fk FOREIGN KEY (office_fk) REFERENCES Office(id)
);


-- PRODUCTS

CREATE TABLE IF NOT EXISTS Category (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(255) DEFAULT NULL
)COMMENT='Product Categories';

CREATE TABLE IF NOT EXISTS Subcategory (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  category_fk INT UNSIGNED NOT NULL,
  name VARCHAR(255) DEFAULT NULL,
    
  CONSTRAINT subcategory_category_fk FOREIGN KEY (category_fk) REFERENCES Category(id)
)COMMENT='Product Subcategories';

CREATE TABLE IF NOT EXISTS Measurement_Unit (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  mu_key VARCHAR(16) DEFAULT NULL,
  description VARCHAR(64) DEFAULT NULL
)COMMENT='Product Measurement Units';

CREATE TABLE IF NOT EXISTS Discount (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  qty DECIMAL(10,2) NOT NULL
)COMMENT='Product Discounts';

CREATE TABLE IF NOT EXISTS Product (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  subcategory_fk INT UNSIGNED DEFAULT NULL,
  mesurement_unit_fk INT UNSIGNED DEFAULT NULL,
  discount_fk INT UNSIGNED NOT NULL,
  name VARCHAR(128) DEFAULT NULL,
  description VARCHAR(255) DEFAULT NULL,
  sku VARCHAR(128) DEFAULT NULL,
  weight DECIMAL(10, 2) DEFAULT NULL,

  CONSTRAINT product_subcategory_fk FOREIGN KEY (subcategory_fk) REFERENCES Subcategory(id),
  CONSTRAINT product_measurementunit_fk FOREIGN KEY (mesurement_unit_fk) REFERENCES Measurement_Unit(id),
  CONSTRAINT product_discount_fk FOREIGN KEY (discount_fk) REFERENCES Discount(id)
);

CREATE TABLE IF NOT EXISTS Office_Product (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  office_fk INT UNSIGNED NOT NULL,
  product_fk INT UNSIGNED NOT NULL,
  stock DECIMAL(10,2) NOT NULL,
  sell_price DECIMAL(10,2) NOT NULL,
  utility DECIMAL(10,2) NOT NULL,
  
  CONSTRAINT officeproduct_office_fk FOREIGN KEY (office_fk) REFERENCES Office(id),
  CONSTRAINT officeproduct_product_fk FOREIGN KEY (product_fk) REFERENCES Product(id)
);

CREATE TABLE IF NOT EXISTS Office_Product_History (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  office_product_fk INT UNSIGNED NOT NULL,
  sell_price DECIMAL(10,2) NOT NULL,
  utility DECIMAL(10,2) NOT NULL,
  price_update DATETIME DEFAULT NOW(),
  
  CONSTRAINT officeproducthistory_officeproduct_fk FOREIGN KEY (office_product_fk) REFERENCES Office_Product(id)
);

-- CLIENTS

CREATE TABLE IF NOT EXISTS Fiscal_Client (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  rfc VARCHAR(32) DEFAULT NULL UNIQUE,
  razon_social VARCHAR(255) DEFAULT NULL,
  email VARCHAR(128) DEFAULT NULL,
  street VARCHAR(255) DEFAULT NULL,
  ext_num VARCHAR(32) DEFAULT NULL,
  int_num VARCHAR(32) DEFAULT NULL,
  neighborhood VARCHAR(64) DEFAULT NULL,
  cp MEDIUMINT UNSIGNED DEFAULT NULL,
  phone_number VARCHAR(32) DEFAULT NULL,
  town VARCHAR(128) DEFAULT NULL,
  state VARCHAR(128) DEFAULT NULL
);

CREATE TABLE IF NOT EXISTS Client (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  office_fk INT UNSIGNED NOT NULL,
  client_fiscal_fk INT UNSIGNED DEFAULT NULL,
  first_names VARCHAR(255) NOT NULL,
  last_names VARCHAR(255) NOT NULL,
  email VARCHAR(128) DEFAULT NULL,
  landline VARCHAR(32) DEFAULT NULL,
  mobile_phone VARCHAR(32) DEFAULT NULL,
  creation_date DATETIME DEFAULT NOW(),

  CONSTRAINT client_office_fk FOREIGN KEY (office_fk) REFERENCES office(id),
  CONSTRAINT client_fiscalclient_fk FOREIGN KEY (client_fiscal_fk) REFERENCES Fiscal_Client(id)
);

-- SALES

CREATE TABLE IF NOT EXISTS Sale (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_fk INT UNSIGNED NOT NULL,
  client_fk INT UNSIGNED DEFAULT NULL,
  transaction_num INT UNSIGNED NOT NULL UNIQUE,
  iva DECIMAL(20, 2) NOT NULL,
  subtotal DECIMAL(20, 2) NOT NULL,
  total DECIMAL(20, 2) NOT NULL,
  products_qty MEDIUMINT UNSIGNED UNSIGNED NOT NULL,
  status VARCHAR(64) COMMENT 'confirm or order',
  order_status BOOLEAN DEFAULT FALSE COMMENT 'FALSE if sale, TRUE if order',
  creation_date DATETIME DEFAULT NOW(),

  CONSTRAINT sale_user_fk FOREIGN KEY (user_fk) REFERENCES User(id),
  CONSTRAINT sale_client_fk FOREIGN KEY (client_fk) REFERENCES Client(id)
);

CREATE TABLE IF NOT EXISTS Sale_Detail (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  sale_fk INT UNSIGNED NOT NULL,
  product_fk INT UNSIGNED NOT NULL,
  iva DECIMAL(20, 2) NOT NULL,
  subtotal DECIMAL(20, 2) NOT NULL,
  totaL DECIMAL(20, 2) NOT NULL,

  CONSTRAINT saledetail_sale_fk FOREIGN KEY (sale_fk) REFERENCES Sale(id),
  CONSTRAINT saledetail_product_fk FOREIGN KEY (product_fk) REFERENCES Product(id)
)COMMENT='A row per sold product';

-- PROVIDERS

CREATE TABLE IF NOT EXISTS Provider (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  person_type VARCHAR(32) NOT NULL,
  name VARCHAR(255) NOT NULL,
  comercial_name VARCHAR(255) NOT NULL UNIQUE,
  rfc VARCHAR(32) NOT NULL UNIQUE,
  phone_number VARCHAR(32) DEFAULT NULL,
  email VARCHAR(128) DEFAULT NULL UNIQUE,
  street VARCHAR(255) DEFAULT NULL,
  ext_num VARCHAR(32) DEFAULT NULL,
  int_num VARCHAR(32) DEFAULT NULL,
  neighborhood VARCHAR(64) DEFAULT NULL,
  cp MEDIUMINT UNSIGNED DEFAULT NULL,
  creation_date DATETIME DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS Office_Provider (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  office_fk INT UNSIGNED NOT NULL,
  provider_fk INT UNSIGNED NOT NULL,
  
  CONSTRAINT officeprovider_office_fk FOREIGN KEY (office_fk) REFERENCES Office(id),
  CONSTRAINT officeprovider_provider_fk FOREIGN KEY (provider_fk) REFERENCES Provider(id)
);

CREATE TABLE IF NOT EXISTS Provider_Product (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  provider_fk INT UNSIGNED NOT NULL,
  product_fk INT UNSIGNED NOT NULL,
  sell_price DECIMAL(10,2) NOT NULL,
  
  CONSTRAINT providerproduct_provider_fk FOREIGN KEY (provider_fk) REFERENCES Provider(id),
  CONSTRAINT providerproduct_product_fk FOREIGN KEY (product_fk) REFERENCES Product(id)
);

CREATE TABLE IF NOT EXISTS Provider_Product_History (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  provider_product_fk INT UNSIGNED NOT NULL,
  sell_price DECIMAL(10,2) NOT NULL,
  price_update DATETIME DEFAULT NOW(),
  
  CONSTRAINT providerproducthistory_providerproduct_fk FOREIGN KEY (provider_product_fk) REFERENCES Provider_Product(id)
);

CREATE TABLE IF NOT EXISTS Provider_Contact (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  provider_fk INT UNSIGNED NOT NULL,
  first_names VARCHAR(255) NOT NULL,
  last_names VARCHAR(255) NOT NULL,
  phone_number VARCHAR(32) DEFAULT NULL,
  email VARCHAR(128) DEFAULT NULL,
  position VARCHAR(64) DEFAULT NULL,
  
  CONSTRAINT providercontact_provider_fk FOREIGN KEY (provider_fk) REFERENCES Provider(id)
)COMMENT='Provider´s contacts';

CREATE TABLE IF NOT EXISTS Provider_Bank (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  provider_fk INT UNSIGNED NOT NULL,
  name VARCHAR(255) NOT NULL,
  account_number VARCHAR(128) NOT NULL,
  clabe BIGINT UNSIGNED NOT NULL,
  account_holder VARCHAR(128) NOT NULL,
  
  CONSTRAINT providerbank_provider_fk FOREIGN KEY (provider_fk) REFERENCES Provider(id)
)COMMENT='Provider´s banks';

-- BUYS

CREATE TABLE IF NOT EXISTS Buy (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_fk INT UNSIGNED NOT NULL,
  provider_fk INT UNSIGNED NOT NULL,
  iva DECIMAL(20, 2) NOT NULL,
  subtotal DECIMAL(20, 2) NOT NULL,
  total DECIMAL(20, 2) NOT NULL,
  products_qty MEDIUMINT UNSIGNED NOT NULL,
  creation_date DATETIME DEFAULT NOW(),
  
  CONSTRAINT buy_user_fk FOREIGN KEY (user_fk) REFERENCES User(id),
  CONSTRAINT buy_provider_fk FOREIGN KEY (provider_fk) REFERENCES Provider(id)
);

CREATE TABLE IF NOT EXISTS Buy_Detail (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  buy_fk INT UNSIGNED NOT NULL,
  product_fk INT UNSIGNED NOT NULL,
  iva DECIMAL(20, 2) NOT NULL,
  subtotal DECIMAL(20, 2) NOT NULL,
  total DECIMAL(20, 2) NOT NULL,
  
  CONSTRAINT buydetail_buy_fk FOREIGN KEY (buy_fk) REFERENCES Buy(id),
  CONSTRAINT buydetail_product_fk FOREIGN KEY (product_fk) REFERENCES Product(id)
)COMMENT='A row per bought product';

-- OTHERS

CREATE TABLE IF NOT EXISTS Devolution (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_fk INT UNSIGNED NOT NULL,
  total DECIMAL(20, 2) NOT NULL,
  products_qty MEDIUMINT UNSIGNED NOT NULL,
  reason VARCHAR(255) NOT NULL,
  creation_date DATETIME DEFAULT NOW(),
  
  CONSTRAINT devolution_user FOREIGN KEY (user_fk) REFERENCES User(id)
);

CREATE TABLE IF NOT EXISTS Devolution_Detail (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  devolution_fk INT UNSIGNED NOT NULL,
  product_fk INT UNSIGNED NOT NULL,
  total DECIMAL(20, 2) NOT NULL,
  
  CONSTRAINT devolutiondetail_devolution_fk FOREIGN KEY (devolution_fk) REFERENCES Devolution(id),
  CONSTRAINT devolutiondetail_product_fk FOREIGN KEY (product_fk) REFERENCES Product(id)
)COMMENT='A row per returned product';

CREATE TABLE IF NOT EXISTS Product_Expense (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_fk INT UNSIGNED NOT NULL,
  product_fk INT UNSIGNED NOT NULL,
  reason VARCHAR(255),
  decrease BOOLEAN DEFAULT FALSE,
  consumable BOOLEAN DEFAULT FALSE COMMENT 'if the product expense it was for other products (TRUE) or it leaves for others reasons',
  creation_date DATETIME DEFAULT NOW(),
  
  CONSTRAINT productexpense_user_fk FOREIGN KEY (user_fk) REFERENCES User(id),
  CONSTRAINT productexpense_product_fk FOREIGN KEY (product_fk) REFERENCES Product(id)
);