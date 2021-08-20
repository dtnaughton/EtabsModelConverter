using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Wall : Shell
    {
        public Wall(string propertyName, ShellPropertyModifiers shellPropertyModifiers, IMaterial material, double thickness)
            : base(propertyName, shellPropertyModifiers, material, thickness)
        {
            SectionType = SectionType.Wall;
        }

        public Wall(string uniqueName, string propertyName) : base(uniqueName, propertyName)
        {

        }
    }
}
