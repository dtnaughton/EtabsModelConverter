using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class ConcreteMaterial : IMaterial
    {
        public string Name { get; set; }
        public double MaterialStrength { get; set ; }
    }
}
