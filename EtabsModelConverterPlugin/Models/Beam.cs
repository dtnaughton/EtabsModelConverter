using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Beam : Frame
    {
        public Beam(string propertyName, FramePropertyModifiers framePropertyModifiers, IMaterial material, Geometry geometry) : base(propertyName, framePropertyModifiers, material, geometry)
        {
            SectionType = SectionType.Beam;
        }

        public Beam(string uniqueName, string propertyName) : base(uniqueName, propertyName)
        {

        }
    }
}
