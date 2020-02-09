using System;
using System.Collections.Generic;

namespace CoreAppSQLDBInAzure.Models
{
    public partial class ProductCatagory
    {
        public ProductCatagory()
        {
            Product = new HashSet<Product>();
        }

        public int CatagoryId { get; set; }
        public string Catagory { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
