using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeShop.Models
{
    public partial class VProductAndDescription
    {
        [Key]
        public int ProductId { get; set; }      // this field is PK
        public string Name { get; set; }
        public string ProductModel { get; set; }
        public int ProductModelId { get; set; }
        public DateTime? SellEndDate { get; set; }      // nullable
        public int ProductCategoryId { get; set; }
        public string Culture { get; set; }
        public string Description { get; set; }
    }
}
