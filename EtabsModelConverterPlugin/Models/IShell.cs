using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public interface IShell
    {
        ShellPropertyModifiers PropertyModifiers { get; set; }
        double Thickness { get; set; }
    }
}
