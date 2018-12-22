using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain
{
    public class ClothesColor : BaseObject
    {
        public int ClothesId { get; set; }
        public int ColorId { get; set; }
    }
}
