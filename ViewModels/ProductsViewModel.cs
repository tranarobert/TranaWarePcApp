﻿using System.Collections.Generic;

namespace TranaWarePc.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<PcComponent> Products { get; set; }
        public int TotalProducts { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}

