using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain
{
    public class Stock : BaseObject
    {
        public int ClothesId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int RateId { get; set; }
        public int Quantity { get; set; }
        public QuantityType QuantityType { get; set; }
    }
}
