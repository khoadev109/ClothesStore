using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain
{
    public class ClothesRate : BaseObject
    {
        public int ClothesId { get; set; }
        public int RateId { get; set; }
        public double Price { get; set; }
    }
}
