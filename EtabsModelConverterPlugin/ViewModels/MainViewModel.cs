using EtabsModelConverterPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.ViewModels
{
    public class MainViewModel
    {
        public EtabsAPI ActiveModel { get; set; }

        public MainViewModel()
        {
            ActiveModel = new EtabsAPI();
            string name = "";
            ActiveModel.SapModel.FrameObj.AddByCoord(0, 0, 0, 3, 3, 3, ref name);
            
        }
    }
}
