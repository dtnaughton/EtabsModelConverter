using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;


namespace EtabsModelConverterPlugin.Models
{
    public class Frame : Section, IFrame
    {
        public FramePropertyModifiers PropertyModifiers { get; set; }
        public Geometry Geometry { get; set; }

        public Frame(string propertyName, FramePropertyModifiers framePropertyModifiers, IMaterial material, Geometry geometry) : base(propertyName, material)
        {
            PropertyModifiers = framePropertyModifiers;
            Geometry = geometry;
        }
    }
}