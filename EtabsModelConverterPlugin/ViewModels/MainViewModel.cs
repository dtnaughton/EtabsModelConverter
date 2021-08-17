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
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ActiveModel = new EtabsAPI();

            WallsUls = new ObservableCollection<Wall>();
            WallsSls = new ObservableCollection<Wall>();
            SlabsUls = new ObservableCollection<Slab>();
            SlabsSls = new ObservableCollection<Slab>();
            DropPanelsUls = new ObservableCollection<DropPanel>();
            DropPanelsSls = new ObservableCollection<DropPanel>();
            ColumnsUls = new ObservableCollection<Column>();
            ColumnsSls = new ObservableCollection<Column>();
            BeamsUls = new ObservableCollection<Beam>();
            BeamsSls = new ObservableCollection<Beam>();
            

            PopulateData();
        }

        public void PopulateData()
        {
            SlabsUls = ObjectFactoryMethods.CreateMultipleSlabs(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetSlabNames(ActiveModel), "ULS"));
            SlabsSls = ObjectFactoryMethods.CreateMultipleSlabs(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetSlabNames(ActiveModel), "SLS"));
            WallsUls = ObjectFactoryMethods.CreateMultipleWalls(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetWallNames(ActiveModel), "ULS"));
            WallsSls = ObjectFactoryMethods.CreateMultipleWalls(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetWallNames(ActiveModel), "SLS"));
            DropPanelsUls = ObjectFactoryMethods.CreateMultipleDropPanels(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetDropNames(ActiveModel), "ULS"));
            DropPanelsSls = ObjectFactoryMethods.CreateMultipleDropPanels(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetDropNames(ActiveModel), "SLS"));
            ColumnsUls = ObjectFactoryMethods.CreateMultipleColumns(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetColumnNames(ActiveModel), "ULS"));
            ColumnsSls = ObjectFactoryMethods.CreateMultipleColumns(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetColumnNames(ActiveModel), "SLS"));
            BeamsUls = ObjectFactoryMethods.CreateBeams(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetBeamNames(ActiveModel), "ULS"));
            BeamsSls = ObjectFactoryMethods.CreateBeams(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetBeamNames(ActiveModel), "SLS"));
            IsULS = EtabsMethods.AreUlsPropertiesApplied(ActiveModel);
            IsSLS = !IsULS;
        }
    }
}
