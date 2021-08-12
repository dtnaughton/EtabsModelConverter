using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace EtabsModelConverter.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public List<string> IntegerList { get; set; }
         
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            IntegerList = new List<string>() 
            { 
                "W200C30-ULS", 
                "W250C30-ULS", 
                "W300C30-ULS", 
                "W300C50-ULS",
            };
        }
    }
}