using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class DropPanel : Shell 
    {
        public DropPanel(string propertyName, ShellPropertyModifiers shellPropertyModifiers, IMaterial material, double thickness)
    : base(propertyName, shellPropertyModifiers, material, thickness)
        {
            SectionType = SectionType.Drop;
        }

        public DropPanel(string uniqueName, string propertyName) : base(uniqueName, propertyName)
        {

        }
    }
}
