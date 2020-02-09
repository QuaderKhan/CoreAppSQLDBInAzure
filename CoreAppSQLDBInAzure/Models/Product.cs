using System;
using System.Collections.Generic;

namespace CoreAppSQLDBInAzure.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCatagory { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCode { get; set; }
        public string ProductImageUrl { get; set; }

        public virtual ProductCatagory ProductCatagoryNavigation { get; set; }
    }
}
