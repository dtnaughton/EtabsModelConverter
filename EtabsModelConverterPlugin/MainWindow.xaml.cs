using EtabsModelConverterPlugin.ViewModels;
using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EtabsModelConverterPlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private cPluginCallback plugin = null;
        private cSapModel sapModel = null;
        private MainViewModel mainViewModel = new MainViewModel();
        

        public MainWindow(ref cSapModel _sapModel, ref cPluginCallback _plugin)
        {
            sapModel = _sapModel;
            plugin = _plugin;
            InitializeComponent();
            DataContext = mainViewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            plugin.Finish(0);
            mainViewModel = null;
        }

        private void SelectAddress(object sender, RoutedEventArgs e)

        {

            TextBox tb = (sender as TextBox);

            if (tb != null)

            {

                tb.SelectAll();

            }

        }



        private void SelectivelyIgnoreMouseButton(object sender,

            MouseButtonEventArgs e)

        {

            TextBox tb = (sender as TextBox);

            if (tb != null)

            {

                if (!tb.IsKeyboardFocusWithin)

                {

                    e.Handled = true;

                    tb.Focus();

                }

            }

        }
    }
}
