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
            SlabsUls = ObjectFactoryMethods.CreateSlabs(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetSlabNames(ActiveModel), "ULS"));
            SlabsSls = ObjectFactoryMethods.CreateSlabs(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetSlabNames(ActiveModel), "SLS"));
            WallsUls = ObjectFactoryMethods.CreateWalls(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetWallNames(ActiveModel), "ULS"));
            WallsSls = ObjectFactoryMethods.CreateWalls(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetWallNames(ActiveModel), "SLS"));
            DropPanelsUls = ObjectFactoryMethods.CreateDrops(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetDropNames(ActiveModel), "ULS"));
            DropPanelsSls = ObjectFactoryMethods.CreateDrops(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetDropNames(ActiveModel), "SLS"));
            ColumnsUls = ObjectFactoryMethods.CreateColumns(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetColumnNames(ActiveModel), "ULS"));
            ColumnsSls = ObjectFactoryMethods.CreateColumns(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetColumnNames(ActiveModel), "SLS"));
            BeamsUls = ObjectFactoryMethods.CreateBeams(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetBeamNames(ActiveModel), "ULS"));
            BeamsSls = ObjectFactoryMethods.CreateBeams(ActiveModel, EtabsMethods.FilterNames(EtabsMethods.GetBeamNames(ActiveModel), "SLS"));
        }
    }
}
