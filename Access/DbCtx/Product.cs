using System;
using System.Collections.Generic;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class Product
    {
        public Product()
        {
            BuyDetails = new HashSet<BuyDetail>();
            DevolutionDetails = new HashSet<DevolutionDetail>();
            OfficeProducts = new HashSet<OfficeProduct>();
            ProductExpenses = new HashSet<ProductExpense>();
            ProviderProducts = new HashSet<ProviderProduct>();
            SaleDetails = new HashSet<SaleDetail>();
        }

        public uint Id { get; set; }
        public uint? SubcategoryFk { get; set; }
        public uint? MesurementUnitFk { get; set; }
        public uint DiscountFk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal? Weight { get; set; }

        public virtual Discount DiscountFkNavigation { get; set; }
        public virtual MeasurementUnit MesurementUnitFkNavigation { get; set; }
        public virtual Subcategory SubcategoryFkNavigation { get; set; }
        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
        public virtual ICollection<DevolutionDetail> DevolutionDetails { get; set; }
        public virtual ICollection<OfficeProduct> OfficeProducts { get; set; }
        public virtual ICollection<ProductExpense> ProductExpenses { get; set; }
        public virtual ICollection<ProviderProduct> ProviderProducts { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
