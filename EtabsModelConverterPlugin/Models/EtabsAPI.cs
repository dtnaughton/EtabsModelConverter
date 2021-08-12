using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EtabsModelConverterPlugin.Models
{
    public class EtabsAPI
    {
        private readonly cOAPI etabsObject;
        private readonly cSapModel sapModel;
        public cSapModel SapModel { get => sapModel; }

        public EtabsAPI()
        {
            try
            {
                etabsObject = (cOAPI)Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
                sapModel = etabsObject.SapModel;
            }
            catch
            {
                MessageBox.Show("Failed to attach to ETABS");
                Environment.Exit(1);
            }
            
        }
    }
}
