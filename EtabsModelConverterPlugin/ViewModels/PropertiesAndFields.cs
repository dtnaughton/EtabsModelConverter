using EtabsModelConverterPlugin.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.ViewModels
{
    partial class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Wall> wallsUls;
        private ObservableCollection<Wall> wallsSls;
        private ObservableCollection<Slab> slabsUls;
        private ObservableCollection<Slab> slabsSls;
        private ObservableCollection<DropPanel> dropPanelsUls;
        private ObservableCollection<DropPanel> dropPanelsSls;
        private ObservableCollection<Column> columnsUls;
        private ObservableCollection<Column> columnsSls;
        private ObservableCollection<Beam> beams;
        private Shell selectedShell;
        private Frame selectedFrame;


        public EtabsAPI ActiveModel { get; set; }
        public ObservableCollection<Wall> WallsUls
        {
            get { return wallsUls; }
            set
            {
                wallsUls = value;
                RaisePropertyChanged(nameof(WallsUls));
            }
        }
        public ObservableCollection<Wall> WallsSls
        {
            get { return wallsSls; }
            set
            {
                wallsSls = value;
                RaisePropertyChanged(nameof(WallsSls));
            }
        }
        public ObservableCollection<Slab> SlabsUls
        {
            get { return slabsUls; }
            set
            {
                slabsUls = value;
                RaisePropertyChanged(nameof(SlabsUls));
            }
        }

        public ObservableCollection<Slab> SlabsSls
        {
            get { return slabsSls; }
            set
            {
                slabsSls = value;
                RaisePropertyChanged(nameof(SlabsSls));
            }
        }
        public ObservableCollection<DropPanel> DropPanelsUls
        {
            get { return dropPanelsUls; }
            set
            {
                dropPanelsUls = value;
                RaisePropertyChanged(nameof(DropPanelsUls));
            }
        }

        public ObservableCollection<DropPanel> DropPanelsSls
        {
            get { return dropPanelsSls; }
            set
            {
                dropPanelsSls = value;
                RaisePropertyChanged(nameof(DropPanelsSls));
            }
        }
        public ObservableCollection<Column> ColumnsUls
        {
            get { return columnsUls; }
            set
            {
                columnsUls = value;
                RaisePropertyChanged(nameof(ColumnsUls));
            }
        }
        public ObservableCollection<Column> ColumnsSls
        {
            get { return columnsSls; }
            set
            {
                columnsSls = value;
                RaisePropertyChanged(nameof(ColumnsSls));
            }
        }
        public ObservableCollection<Beam> Beams
        {
            get { return beams; }
            set
            {
                beams = value;
                RaisePropertyChanged(nameof(Beams));
            }
        }

        public Shell SelectedShell
        {
            get { return selectedShell; }
            set
            {
                selectedShell = value;
                RaisePropertyChanged(nameof(SelectedShell));
            }
        }

        public Frame SelectedFrame
        {
            get { return selectedFrame; }
            set
            {
                selectedFrame = value;
                RaisePropertyChanged(nameof(SelectedFrame));
            }
        }
    }
}
