using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public interface IPropertyModifiers
    {
        double Mass { get; set; }
        double Weight { get; set; }
    }
}
