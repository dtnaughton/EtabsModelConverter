using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Beam : Frame
    {
        public Beam(string propertyName, FramePropertyModifiers framePropertyModifiers, double width, double height) : base(propertyName, framePropertyModifiers, width, height)
        {
            SectionType = SectionType.Beam;
        }
    }
}
