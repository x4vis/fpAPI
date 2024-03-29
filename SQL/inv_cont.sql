DROP DATABASE IF EXISTS Business;
CREATE DATABASE IF NOT EXISTS Business DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE Business;

CREATE TABLE IF NOT EXISTS Role (
  RoleId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(64) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS Office (
  OfficeId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(128) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS User (
  UserId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  RoleId INT UNSIGNED NOT NULL,
  OfficeId INT UNSIGNED NOT NULL,
  FirstName VARCHAR(128) NOT NULL,
  MiddleName VARCHAR(128) DEFAULT NULL,
  SurNames VARCHAR(255) DEFAULT NULL,
  Email VARCHAR(128) NOT NULL UNIQUE,
  PhoneNumber VARCHAR(32) DEFAULT NULL,
  Street VARCHAR(255) DEFAULT NULL,
  ExteriorNumber VARCHAR(32) DEFAULT NULL,
  InteriorNumber VARCHAR(32) DEFAULT NULL,
  Neighborhood VARCHAR(64) DEFAULT NULL,
  PostalCode MEDIUMINT UNSIGNED DEFAULT NULL,
  Password TINYBLOB NOT NULL,
  PermissionMask INT UNSIGNED NOT NULL,
  Status BOOLEAN DEFAULT TRUE,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL

  CONSTRAINT UserRolFk
  FOREIGN KEY (RoleId)
  REFERENCES Role(RoleId),

  CONSTRAINT UserOfficeFk
  FOREIGN KEY (OfficeId)
  REFERENCES Office(OfficeId)
);

CREATE TABLE IF NOT EXISTS Token (
  TokenId INT UNSIGNED NOT NULL PRIMARY KEY,
  Value VARCHAR(510) NOT NULL,
  ExperationDate DATETIME NOT NULL,
  CreatedDate DATETIME DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS Permission (
  Mask INT UNSIGNED NOT NULL PRIMARY KEY,
  Name VARCHAR(64) NOT NULL,
  ParentMask INT UNSIGNED DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
)

CREATE TABLE IF NOT EXISTS Category (
  CategoryId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(255) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS SubCategory (
  SubCategoryId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(255) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS CategorySubCategory (
  CategoryId INT UNSIGNED NOT NULL,
  SubCategoryId INT UNSIGNED NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
  PRIMARY KEY (CategoryId, SubCategoryId),

  CONSTRAINT CategorySubCategoryCategoryFk
  FOREIGN KEY (CategoryId) 
  REFERENCES Category(CategoryId),

  CONSTRAINT CategorySubCategorySubCategoryFk
  FOREIGN KEY (SubCategoryId)
  REFERENCES SubCategory(SubCategoryId)
);

CREATE TABLE IF NOT EXISTS MeasurementUnit (
  MeasurementUnitId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  key VARCHAR(16) DEFAULT NULL,
  Name VARCHAR(64) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS Discount (
  DiscountId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Quantity DECIMAL(10,2) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS Product (
  ProductId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  MeasurementUnitId INT UNSIGNED NOT NULL,
  Name VARCHAR(128) DEFAULT NULL,
  Description VARCHAR(255) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,

  CONSTRAINT ProductMeasurementUnitFk
  FOREIGN KEY (MeasurementUnitId)
  REFERENCES MeasurementUnit(MeasurementUnitId),

  CONSTRAINT ProductDiscountFk 
  FOREIGN KEY (DiscountId)
  REFERENCES Discount(DiscountId)
);

CREATE TABLE ImageUrl (
  ImageUrlId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  ProductId INT UNSIGNED NOT NULL,
  Url VARCHAR(500) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,

  CONSTRAINT ImageUrlProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId)
);

CREATE TABLE IF NOT EXISTS ProductCategory (
  ProductId INT UNSIGNED NOT NULL,
  CategoryId INT UNSIGNED NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  PRIMARY KEY (ProductId, CategoryId),

  CONSTRAINT ProductCategoryProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId),

  CONSTRAINT ProductCategoryCategoryFk
  FOREIGN KEY (CategoryId)
  REFERENCES Category(CategoryId)
);

CREATE TABLE IF NOT EXISTS OfficeProduct (
  OfficeId INT UNSIGNED NOT NULL,
  ProductId INT UNSIGNED NOT NULL,
  DiscountId INT UNSIGNED DEFAULT NULL,
  Stock DECIMAL(10,2) NOT NULL,
  SellPrice DECIMAL(10,2) NOT NULL,
  PriceUpdated DATETIME DEFAULT NOW(),
  Utility DECIMAL(10,2) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  PRIMARY KEY (OfficeId, ProductId),
  
  CONSTRAINT OficeProductOfficeFk
  FOREIGN KEY (OfficeId)
  REFERENCES Office(OfficeId),

  CONSTRAINT OfficeProductProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId),

  CONSTRAINT OfficeProductDiscountFk
  FOREIGN KEY (DiscountId)
  REFERENCES Discount(DiscountId)
);

CREATE TABLE IF NOT EXISTS OfficeProductHistory (
  OfficeProductHistoryId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  OfficeProductId INT UNSIGNED NOT NULL,
  SellPrice DECIMAL(10,2) NOT NULL,
  Utility DECIMAL(10,2) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT OfficeProductHistoryOfficeProductFk
  FOREIGN KEY (OfficeProductId)
  REFERENCES OfficeProduct(OfficeProductId)
);

CREATE TABLE IF NOT EXISTS FiscalClient (
  FiscalClientId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  KindOfPerson VARCHAR(32) NOT NULL,
  RFC VARCHAR(32) NOT NULL UNIQUE,
  BusinessName VARCHAR(510) NOT NULL,
  TradingName VARCHAR(510) NOT NULL,
  Email VARCHAR(128) NOT NULL UNIQUE,
  Street VARCHAR(255) NOT NULL,
  ExteriorNumber VARCHAR(32) NOT NULL,
  InteriorNumber VARCHAR(32) NOT NULL,
  Neighborhood VARCHAR(64) NOT NULL,
  PostalCode MEDIUMINT UNSIGNED NOT NULL,
  PhoneNumber VARCHAR(32) DEFAULT NULL,
  Town VARCHAR(128) NOT NULL,
  State VARCHAR(128) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
);

CREATE TABLE IF NOT EXISTS Client (
  ClientId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  OfficeId INT UNSIGNED NOT NULL,
  FiscalClientId INT UNSIGNED DEFAULT NULL,
  FirstName VARCHAR(128) NOT NULL,
  MiddleName VARCHAR(128) DEFAULT NULL,
  SurNames VARCHAR(255) DEFAULT NULL,
  Email VARCHAR(128) DEFAULT NULL UNIQUE,
  LandLine VARCHAR(32) DEFAULT NULL,
  MobilePhone VARCHAR(32) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,

  CONSTRAINT ClientOfficeFk
  FOREIGN KEY (OfficeId)
  REFERENCES Office(OfficeId),

  CONSTRAINT ClientFiscalClientFk
  FOREIGN KEY (FiscalClientId)
  REFERENCES FiscalClient(FiscalClientId)
);

CREATE TABLE IF NOT EXISTS Sale (
  SaleId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  UserId INT UNSIGNED NOT NULL,
  ClientId INT UNSIGNED DEFAULT NULL,
  TransactionNumber INT UNSIGNED NOT NULL UNIQUE,
  IVA DECIMAL(20, 2) NOT NULL,
  SubTotal DECIMAL(20, 2) NOT NULL,
  Total DECIMAL(20, 2) NOT NULL,
  QuantityItems MEDIUMINT UNSIGNED NOT NULL,
  Status VARCHAR(64) COMMENT 'pending || closed',
  Type VARCHAR(16) NOT NULL COMMENT 'sale || order',
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,

  CONSTRAINT SaleUserFk
  FOREIGN KEY (UserId)
  REFERENCES User(UserId),

  CONSTRAINT SaleClientFk
  FOREIGN KEY (ClientId)
  REFERENCES Client(ClientId)
);

CREATE TABLE IF NOT EXISTS SaleDetail (
  SaleDetailId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  SaleId INT UNSIGNED NOT NULL,
  ProductId INT UNSIGNED NOT NULL,
  IVA DECIMAL(20, 2) NOT NULL,
  SubTotal DECIMAL(20, 2) NOT NULL,
  TotaL DECIMAL(20, 2) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,

  CONSTRAINT SaleDetailSaleFk
  FOREIGN KEY (SaleId)
  REFERENCES Sale(SaleId),

  CONSTRAINT SaleDetailProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId)
);

CREATE TABLE IF NOT EXISTS Vendor (
  VendorId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  BusinessName VARCHAR(510) NOT NULL,
  TradingName VARCHAR(510) NOT NULL,
  KindOfPerson VARCHAR(32) NOT NULL,
  RFC VARCHAR(32) NOT NULL UNIQUE,
  PhoneNumber VARCHAR(32) DEFAULT NULL,
  Email VARCHAR(128) DEFAULT NULL UNIQUE,
  Street VARCHAR(255) DEFAULT NULL,
  ExteriorNumber VARCHAR(32) DEFAULT NULL,
  InteriorNumber VARCHAR(32) DEFAULT NULL,
  Neighborhood VARCHAR(64) DEFAULT NULL,
  PostalCode MEDIUMINT UNSIGNED DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
);

CREATE TABLE IF NOT EXISTS OfficeVendor (
  OfficeVendorId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  OfficeId INT UNSIGNED NOT NULL,
  VendorId INT UNSIGNED NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT OfficeVendorOfficeFk
  FOREIGN KEY (OfficeId)
  REFERENCES Office(OfficeId),

  CONSTRAINT OfficeVendorProviderFk
  FOREIGN KEY (VendorId)
  REFERENCES Vendor(VendorId)
);

CREATE TABLE IF NOT EXISTS VendorProduct (
  VendorProductId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  VendorId INT UNSIGNED NOT NULL,
  ProductId INT UNSIGNED NOT NULL,
  SellPrice DECIMAL(10,2) NOT NULL,
  QuantityPerUnit DECIMAL(10, 2) DEFAULT NULL,
  SKU VARCHAR(128) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT VendorProductVendorFk
  FOREIGN KEY (VendorId)
  REFERENCES Vendor(VendorId),

  CONSTRAINT VendorProductProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId)
);

CREATE TABLE IF NOT EXISTS VendorProductHistory (
  VendorProductHistoryId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  VendorProductId INT UNSIGNED NOT NULL,
  SellPrice DECIMAL(10,2) NOT NULL,
  PriceUpdated DATETIME DEFAULT NOW(),
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT VendorProductHistoryVendorProductFk
  FOREIGN KEY (VendorProductId)
  REFERENCES VendorProduct(VendorProductId)
);

CREATE TABLE IF NOT EXISTS VendorContact (
  VendorContactId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  VendorId INT UNSIGNED NOT NULL,
  FirstName VARCHAR(128) NOT NULL,
  MiddleName VARCHAR(128) DEFAULT NULL,
  SurNames VARCHAR(255) DEFAULT NULL,
  PhoneNumber VARCHAR(32) DEFAULT NULL,
  Email VARCHAR(128) DEFAULT NULL UNIQUE,
  Position VARCHAR(64) DEFAULT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT VendorContactVendorFk
  FOREIGN KEY (VendorId)
  REFERENCES Vendor(VendorId)
);

CREATE TABLE IF NOT EXISTS VendorBank (
  VendorBankId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  VendorId INT UNSIGNED NOT NULL,
  Name VARCHAR(255) NOT NULL,
  AccountNumber VARCHAR(128) NOT NULL,
  Clabe BIGINT UNSIGNED NOT NULL,
  AccountHolder VARCHAR(128) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT VendorBankVendorFk
  FOREIGN KEY (VendorId)
  REFERENCES Vendor(VendorId)
);

CREATE TABLE IF NOT EXISTS Order (
  OrderId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  UserId INT UNSIGNED NOT NULL,
  VendorId INT UNSIGNED NOT NULL,
  IVA DECIMAL(20, 2) NOT NULL,
  SubTotal DECIMAL(20, 2) NOT NULL,
  TotaL DECIMAL(20, 2) NOT NULL,
  QuantityItems MEDIUMINT UNSIGNED NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT OrderUserFk
  FOREIGN KEY (UserId)
  REFERENCES User(UserId),

  CONSTRAINT OrderVendorFk
  FOREIGN KEY (VendorId)
  REFERENCES Vendor(VendorId)
);

CREATE TABLE IF NOT EXISTS OrderDetail (
  OrderDetailId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  OrderId INT UNSIGNED NOT NULL,
  ProductId INT UNSIGNED NOT NULL,
  IVA DECIMAL(20, 2) NOT NULL,
  SubTotal DECIMAL(20, 2) NOT NULL,
  Total DECIMAL(20, 2) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT OrderDetailOrderFk
  FOREIGN KEY (OrderId)
  REFERENCES Order(OrderId),

  CONSTRAINT OrderDetailProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId)
);

CREATE TABLE IF NOT EXISTS Refund (
  RefundId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  UserId INT UNSIGNED NOT NULL,
  Total DECIMAL(20, 2) NOT NULL,
  QuantityItems MEDIUMINT UNSIGNED NOT NULL,
  Reason VARCHAR(255) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT RefundUserFk
  FOREIGN KEY (UserId)
  REFERENCES User(UserId)
);

CREATE TABLE IF NOT EXISTS RefundDetail (
  RefundDetailId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  RefundId INT UNSIGNED NOT NULL,
  ProductId INT UNSIGNED NOT NULL,
  Total DECIMAL(20, 2) NOT NULL,
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT RefundDetailRefundFk
  FOREIGN KEY (RefundId)
  REFERENCES Refund(RefundId),
  
  CONSTRAINT RefundDetailProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId)
);

CREATE TABLE IF NOT EXISTS ExpenseType (
  ExpenseTypeId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Type VARCHAR(64) COMMENT 'DECREASE || CONSUMABLE',
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
);

CREATE TABLE IF NOT EXISTS ProductExpense (
  ProductExpenseId INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  UserId INT UNSIGNED NOT NULL,
  ProductId INT UNSIGNED NOT NULL,
  ExpenseTypeId INT UNSIGNED NOT NULL,
  Reason VARCHAR(255),
  CreatedBy VARCHAR(255) NOT NULL,
  CreatedDate DATETIME DEFAULT NOW(),
  LastModifiedBy VARCHAR(255) NOT NULL,
  LastModifiedDate DATETIME NOT NULL,
  
  CONSTRAINT ProductExpenseUserFk
  FOREIGN KEY (UserId)
  REFERENCES User(UserId),

  CONSTRAINT ProductExpenseProductFk
  FOREIGN KEY (ProductId)
  REFERENCES Product(ProductId),

  CONSTRAINT ProductExpenseExpenseType
  FOREIGN KEY (ExpenseTypeId)
  REFERENCES ExpenseType(ExpenseTypeId)
);