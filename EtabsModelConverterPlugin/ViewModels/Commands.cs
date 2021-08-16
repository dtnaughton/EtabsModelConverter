using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EtabsModelConverterPlugin.ViewModels
{
    /// <summary>
    /// Class provides commands for UI buttons to bind to
    /// </summary>
    partial class MainViewModel : ViewModelBase
    {
        public ICommand ApplyFramePropertiesCommand
        {
            get { return new RelayCommand(ApplyFrameProperties, true); }
        }

        private void ApplyFrameProperties()
        {
            double[] propertyModifiers = new double[]
            {
                SelectedFrame.PropertyModifiers.CrossSectionalArea,
                SelectedFrame.PropertyModifiers.ShearArea2Direction,
                SelectedFrame.PropertyModifiers.ShearArea3Direction,
                SelectedFrame.PropertyModifiers.TorsionalConstant,
                SelectedFrame.PropertyModifiers.MomentOfInertiaAbout2,
                SelectedFrame.PropertyModifiers.MomentOfInertiaAbout3,
                SelectedFrame.PropertyModifiers.Mass,
                SelectedFrame.PropertyModifiers.Weight
            };

            ActiveModel.SapModel.PropFrame.SetModifiers(SelectedFrame.PropertyName, ref propertyModifiers);
        }
    }
}
