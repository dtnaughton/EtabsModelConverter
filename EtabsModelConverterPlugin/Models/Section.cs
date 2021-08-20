using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Models
{
    public class Section : ISection
    {
        public string PropertyName { get; set; }
        public SectionType SectionType { get; set; }
        public IMaterial Material { get; set; }

        public Section(string propertyName, IMaterial material)
        {
            PropertyName = propertyName;
            Material = material;
        }

        public Section(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string AppendSectionName(string originalName, string textToAppend)
        {
            return StripSectionName(originalName) + textToAppend;
        }

        /// <summary>
        /// Strips section name of "-ULS" or "-SLS"
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string StripSectionName(string fullName)
        {
            string[] words = fullName.Split('-');

            return words.First();
        }

    }
}
