using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain
{
    public class ClothesSize : BaseObject
    {
        public int ClothesId { get; set; }
        public int SizeId { get; set; }
    }
}
