using EtabsModelConverterPlugin.Helpers;
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

        public ICommand SyncPropertiesCommand
        {
            get { return new RelayCommand(SyncProperties, true); }
        }

        private void SyncProperties()
        {
            foreach(var columnULS in ColumnsUls)
            {
                if (!ObjectFactoryMethods.ElementSynced(columnULS, ColumnsSls))
                {
                    ColumnsSls.Add(ObjectFactoryMethods.CreateColumn(ActiveModel, columnULS.PropertyName));
                }
            }

            foreach(var wallULS in WallsUls)
            {
                if(!ObjectFactoryMethods.ElementSynced(wallULS, WallsSls))
                {
                    WallsSls.Add(ObjectFactoryMethods.CreateWall(ActiveModel, wallULS.PropertyName));
                }
            }

            EtabsMethods.CreateWallElementInETABS(ActiveModel, WallsSls);
            
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
