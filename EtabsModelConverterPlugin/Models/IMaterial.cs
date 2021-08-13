using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public interface IMaterial
    {
        string Name { get; set; }
        double MaterialStrength { get; set; }
    }
}
