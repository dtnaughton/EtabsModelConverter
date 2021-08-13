using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class FramePropertyModifiers : IPropertyModifiers
    {
        public double CrossSectionalArea { get; set; }
        public double ShearArea2Direction { get; set; }
        public double ShearArea3Direction { get; set; }
        public double TorsionalConstant { get; set; }
        public double MomentOfInertiaAbout2 { get; set; }
        public double MomentOfInertiaAbout3 { get; set; }
        public double Mass { get; set; }
        public double Weight { get; set; }
    }
}
