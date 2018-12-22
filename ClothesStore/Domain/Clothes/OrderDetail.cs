﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain
{
    public class SellingOrderDetail : BaseObject
    {
        public int OrderId { get; set; }
        public int ClothesId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
