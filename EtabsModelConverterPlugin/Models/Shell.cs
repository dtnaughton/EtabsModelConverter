using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Shell : Section
    {
        public string PropertyName { get; set; }
        public SectionType SectionType { get; set; }
        public ShellPropertyModifiers PropertyModifiers { get; set; }
        public IMaterial Material { get; set; }
        public double Thickness { get; set; }
    }
}
