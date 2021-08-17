using EtabsModelConverterPlugin.Helpers;
using EtabsModelConverterPlugin.Models;
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

        // Add ApplyShellPropertiesCommand
        // Remove hardcode of shell type and add dynamically

        public ICommand SyncPropertiesCommand
        {
            get { return new RelayCommand(SyncProperties, true); }
        }

        private void SyncProperties()
        {
            foreach (var wallULS in WallsUls)
            {
                if (!ObjectFactoryMethods.WallsSynced(wallULS, WallsSls))
                {
                    wallULS.PropertyName = wallULS.AppendSectionName(wallULS.PropertyName, "-SLS");
                    WallsSls.Add(wallULS);
                }
            }
            EtabsMethods.CreateWallElementInETABS(ActiveModel, WallsSls);

            foreach (var wallSLS in WallsSls)
            {
                if (!ObjectFactoryMethods.WallsSynced(wallSLS, WallsUls))
                {
                    wallSLS.PropertyName = wallSLS.AppendSectionName(wallSLS.PropertyName, "-ULS");
                    WallsUls.Add(wallSLS);
                }
            }
            EtabsMethods.CreateWallElementInETABS(ActiveModel, WallsUls);

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
