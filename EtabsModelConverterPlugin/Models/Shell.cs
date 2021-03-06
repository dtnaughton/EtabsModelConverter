using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Shell : Section, IShell
    {
        public ShellPropertyModifiers PropertyModifiers { get; set; }
        public double Thickness { get; set; }

        public string UniqueName { get; set; }

        public Shell(string propertyName, ShellPropertyModifiers shellPropertyModifiers, IMaterial material, double thickness) : base(propertyName, material)
        {
            PropertyModifiers = shellPropertyModifiers;
            Thickness = thickness;
        }

        public Shell(string uniqueName, string propertyName) : base(propertyName)
        {
            UniqueName = uniqueName;
        }
    }
}
