using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    
    public class Column : Frame
    {
        public ColumnType Shape { get; set; }
        public Column(string propertyName, FramePropertyModifiers framePropertyModifiers, IMaterial material, Geometry geometry, ColumnType shape) : base(propertyName, framePropertyModifiers, material, geometry)
        {
            SectionType = SectionType.Column;
            Shape = shape;
        }
    }
}
