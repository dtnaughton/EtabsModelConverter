using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;

namespace EtabsModelConverterPlugin
{
    public class cPlugin
    {
        public void Main(ref cSapModel SapModel, ref cPluginCallback ISapPlugin)
        {
            MainWindow mainWindow = new MainWindow(ref SapModel, ref ISapPlugin);
            ElementHost.EnableModelessKeyboardInterop(mainWindow);
            mainWindow.Show();

        }

        public long Info(ref string Text)
        {
            Text = "Speckle connector for ETABS";
            return 0;
        }
    }
}
