using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Section : ObservableObject, ISection
    {
        public string PropertyName { get; set; }

        public string GetSectionName(string fullName)
        {
            string[] words = fullName.Split('-');

            return words.First();
        }
    }
}
