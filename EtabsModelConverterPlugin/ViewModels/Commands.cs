using EtabsModelConverterPlugin.Helpers;
using EtabsModelConverterPlugin.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICommand ApplyULSOrSLSParametersCommand
        {
            get { return new RelayCommand(ApplyULSorSLSParameters, true); }
        }

        private void SyncProperties()
        {
            foreach (var wallULS in WallsUls)
            {
                if (!ObjectFactoryMethods.WallsSynced(wallULS, WallsSls))
                {
                    WallsSls.Add(new Wall
                        (
                            wallULS.AppendSectionName(wallULS.PropertyName, "-SLS"),
                            wallULS.PropertyModifiers,
                            wallULS.Material,
                            wallULS.Thickness
                        ));

                }
            }
            WallsSls = ObjectFactoryMethods.SortWalls(WallsSls);
            EtabsMethods.CreateWallElementInETABS(ActiveModel, WallsSls);

            foreach (var wallSLS in WallsSls)
            {
                if (!ObjectFactoryMethods.WallsSynced(wallSLS, WallsUls))
                {
                    WallsUls.Add(new Wall
                        (
                            wallSLS.AppendSectionName(wallSLS.PropertyName, "-ULS"),
                            wallSLS.PropertyModifiers,
                            wallSLS.Material,
                            wallSLS.Thickness
                        ));

                }
            }
            WallsUls = ObjectFactoryMethods.SortWalls(WallsUls);
            EtabsMethods.CreateWallElementInETABS(ActiveModel, WallsUls);

            foreach (var slabULS in SlabsUls)
            {
                if (!ObjectFactoryMethods.SlabsSynced(slabULS, SlabsSls))
                {
                    SlabsSls.Add(new Slab
                        (
                            slabULS.AppendSectionName(slabULS.PropertyName, "-SLS"),
                            slabULS.PropertyModifiers,
                            slabULS.Material,
                            slabULS.Thickness
                        ));
                }
            }
            SlabsSls = ObjectFactoryMethods.SortSlabs(SlabsSls);
            EtabsMethods.CreateSlabElementInETABS(ActiveModel, SlabsSls);

            foreach (var slabSLS in SlabsSls)
            {
                if (!ObjectFactoryMethods.SlabsSynced(slabSLS, SlabsUls))
                {
                    SlabsUls.Add(new Slab
                        (
                            slabSLS.AppendSectionName(slabSLS.PropertyName, "-ULS"),
                            slabSLS.PropertyModifiers,
                            slabSLS.Material,
                            slabSLS.Thickness
                        ));
                }
            }
            SlabsUls = ObjectFactoryMethods.SortSlabs(SlabsUls);

            EtabsMethods.CreateSlabElementInETABS(ActiveModel, SlabsUls);

            foreach (var dropULS in DropPanelsUls)
            {
                if (!ObjectFactoryMethods.DropsSynced(dropULS, DropPanelsSls))
                {
                    DropPanelsSls.Add(new DropPanel
                        (
                            dropULS.AppendSectionName(dropULS.PropertyName, "-SLS"),
                            dropULS.PropertyModifiers,
                            dropULS.Material,
                            dropULS.Thickness
                        ));
                }
            }
            DropPanelsSls = ObjectFactoryMethods.SortDrops(DropPanelsSls);
            EtabsMethods.CreateDropElementInETABS(ActiveModel, DropPanelsSls);

            foreach (var dropSLS in DropPanelsSls)
            {
                if (!ObjectFactoryMethods.DropsSynced(dropSLS, DropPanelsUls))
                {
                    DropPanelsUls.Add(new DropPanel
                        (
                            dropSLS.AppendSectionName(dropSLS.PropertyName, "-ULS"),
                            dropSLS.PropertyModifiers,
                            dropSLS.Material,
                            dropSLS.Thickness
                        ));
                }
            }
            DropPanelsUls = ObjectFactoryMethods.SortDrops(DropPanelsUls);
            EtabsMethods.CreateDropElementInETABS(ActiveModel, DropPanelsUls);

            foreach (var beamULS in BeamsUls)
            {
                if (!ObjectFactoryMethods.BeamsSynced(beamULS, BeamsSls))
                {
                    BeamsSls.Add(new Beam
                        (
                            beamULS.AppendSectionName(beamULS.PropertyName, "-SLS"),
                            beamULS.PropertyModifiers,
                            beamULS.Material,
                            beamULS.Geometry
                        ));
                }
            }
            BeamsSls = ObjectFactoryMethods.SortBeams(BeamsSls);
            EtabsMethods.CreateBeamElementInETABS(ActiveModel, BeamsSls);

            foreach (var beamSLS in BeamsSls)
            {
                if (!ObjectFactoryMethods.BeamsSynced(beamSLS, BeamsUls))
                {
                    BeamsUls.Add(new Beam
                        (
                            beamSLS.AppendSectionName(beamSLS.PropertyName, "-ULS"),
                            beamSLS.PropertyModifiers,
                            beamSLS.Material,
                            beamSLS.Geometry
                        ));
                }
            }
            BeamsUls = ObjectFactoryMethods.SortBeams(BeamsUls);
            EtabsMethods.CreateBeamElementInETABS(ActiveModel, BeamsUls);

            foreach (var columnULS in ColumnsUls)
            {
                if (!ObjectFactoryMethods.ColumnsSynced(columnULS, ColumnsSls))
                {
                    ColumnsSls.Add(new Column
                        (
                            columnULS.AppendSectionName(columnULS.PropertyName, "-SLS"),
                            columnULS.PropertyModifiers,
                            columnULS.Material,
                            columnULS.Geometry,
                            columnULS.Shape
                        ));
                }
            }
            ColumnsSls = ObjectFactoryMethods.SortColumns(ColumnsSls);
            EtabsMethods.CreateColumnElementInETABS(ActiveModel, ColumnsSls);

            foreach (var columnSLS in ColumnsSls)
            {
                if (!ObjectFactoryMethods.ColumnsSynced(columnSLS, ColumnsUls))
                {
                    ColumnsUls.Add(new Column
                        (
                            columnSLS.AppendSectionName(columnSLS.PropertyName, "-ULS"),
                            columnSLS.PropertyModifiers,
                            columnSLS.Material,
                            columnSLS.Geometry,
                            columnSLS.Shape
                        ));
                }
            }
            ColumnsUls = ObjectFactoryMethods.SortColumns(ColumnsUls);
            EtabsMethods.CreateColumnElementInETABS(ActiveModel, ColumnsUls);
        }

        /// <summary>
        /// Applies ULS or SLS properties to all objects in model
        /// </summary>
        private void ApplyULSorSLSParameters()
        {
            if (IsULS)
            {
                EtabsMethods.AssignPropertiesToEtabs(ActiveModel, BeamsUls, ColumnsUls);
            }

            else
            {
                EtabsMethods.AssignPropertiesToEtabs(ActiveModel, BeamsSls, ColumnsSls);
            }
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
