﻿using System;
using System.Collections.Generic;

namespace BikeShop.Models
{
    public partial class VGetAllCategories
    {
        public string ParentProductCategoryName { get; set; }
        public string ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
