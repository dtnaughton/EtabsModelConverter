using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class ShellPropertyModifiers : IPropertyModifiers
    {
        public double F11 { get; set; }
        public double F22 { get; set; }
        public double F12 { get; set; }
        public double M11 { get; set; }
        public double M22 { get; set; }
        public double M12 { get; set; }
        public double V13 { get; set; }
        public double V23 { get; set; }
        public double Mass { get; set; }
        public double Weight { get; set; }
    }
}
