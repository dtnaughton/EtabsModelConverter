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

        public ICommand ApplyShellPropertiesCommand
        {
            get { return new RelayCommand(ApplyShellProperties, true); }
        }

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

            foreach (var slabULS in SlabsUls)
            {
                if (!ObjectFactoryMethods.SlabsSynced(slabULS, SlabsSls))
                {
                    slabULS.PropertyName = slabULS.AppendSectionName(slabULS.PropertyName, "-SLS");
                    SlabsSls.Add(slabULS);
                }
            }
            EtabsMethods.CreateSlabElementInETABS(ActiveModel, SlabsSls);

            foreach (var slabSLS in SlabsSls)
            {
                if (!ObjectFactoryMethods.SlabsSynced(slabSLS, SlabsUls))
                {
                    slabSLS.PropertyName = slabSLS.AppendSectionName(slabSLS.PropertyName, "-SLS");
                    SlabsUls.Add(slabSLS);
                }
            }
            EtabsMethods.CreateSlabElementInETABS(ActiveModel, SlabsUls);

            foreach (var dropULS in dropPanelsUls)
            {
                if (!ObjectFactoryMethods.DropsSynced(dropULS, DropPanelsSls))
                {
                    dropULS.PropertyName = dropULS.AppendSectionName(dropULS.PropertyName, "-SLS");
                    DropPanelsSls.Add(dropULS);
                }
            }
            EtabsMethods.CreateDropElementInETABS(ActiveModel, DropPanelsSls);

            foreach (var dropSLS in dropPanelsSls)
            {
                if (!ObjectFactoryMethods.DropsSynced(dropSLS, DropPanelsUls))
                {
                    dropSLS.PropertyName = dropSLS.AppendSectionName(dropSLS.PropertyName, "-SLS");
                    DropPanelsUls.Add(dropSLS);
                }
            }
            EtabsMethods.CreateDropElementInETABS(ActiveModel, DropPanelsUls);


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

        private void ApplyShellProperties()
        {
            double[] propertyModifiers = new double[]
            {
                SelectedShell.PropertyModifiers.F11,
                SelectedShell.PropertyModifiers.F22,
                SelectedShell.PropertyModifiers.F12,
                SelectedShell.PropertyModifiers.M11,
                SelectedShell.PropertyModifiers.M22,
                SelectedShell.PropertyModifiers.M12,
                SelectedShell.PropertyModifiers.V13,
                SelectedShell.PropertyModifiers.V23,
                SelectedShell.PropertyModifiers.Mass,
                SelectedShell.PropertyModifiers.Weight
            };

            ActiveModel.SapModel.PropArea.SetModifiers(SelectedFrame.PropertyName, ref propertyModifiers);
        }
    }
}
