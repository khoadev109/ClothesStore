using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain
{
    public class Clothes : BaseObject
    {
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int TypeId { get; set; }
    }
}
