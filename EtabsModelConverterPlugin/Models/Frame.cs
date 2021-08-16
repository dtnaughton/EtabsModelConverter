using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;


namespace EtabsModelConverterPlugin.Models
{
    public class Frame : Section
    {
        private FramePropertyModifiers propertyModifiers;
        public string PropertyName { get; set; }
        public SectionType SectionType { get; set; }
        public FramePropertyModifiers PropertyModifiers
        {
            get { return propertyModifiers; }
            set
            {
                propertyModifiers = value;
                RaisePropertyChanged(nameof(PropertyModifiers));
            }
        }
                
        public IMaterial Material { get; set; }
    }
}
