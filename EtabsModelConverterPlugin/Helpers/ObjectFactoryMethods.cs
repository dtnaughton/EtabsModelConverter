using EtabsModelConverterPlugin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsModelConverterPlugin.Helpers
{
    public class ObjectFactoryMethods
    {
        public static ObservableCollection<Slab> CreateMultipleSlabs(EtabsAPI activeModel, List<string> slabNames)
        {
            var slabs = new ObservableCollection<Slab>();

            foreach (var slabName in slabNames)
            {
                slabs.Add(new Slab(
                    slabName,
                    EtabsMethods.GetShellPropertyModifiers(activeModel, slabName),
                    EtabsMethods.GetSlabMaterial(activeModel, slabName),
                    EtabsMethods.GetSlabThickness(activeModel, slabName)));
            }

            return slabs;
        }
        public static ObservableCollection<DropPanel> CreateMultipleDropPanels(EtabsAPI activeModel, List<string> dropNames)
        {
            var drops = new ObservableCollection<DropPanel>();

            foreach (var dropName in dropNames)
            {
                drops.Add(new DropPanel(
                    dropName,
                    EtabsMethods.GetShellPropertyModifiers(activeModel, dropName),
                    EtabsMethods.GetSlabMaterial(activeModel, dropName),
                    EtabsMethods.GetSlabThickness(activeModel, dropName)));
            }
        
            return drops;
        }

        public static ObservableCollection<Wall> CreateMultipleWalls(EtabsAPI activeModel, List<string> wallNames)
        {
            var walls = new ObservableCollection<Wall>();

            foreach (var wallName in wallNames)
            {
                walls.Add(new Wall(
                    wallName,
                    EtabsMethods.GetShellPropertyModifiers(activeModel, wallName),
                    EtabsMethods.GetSlabMaterial(activeModel, wallName),
                    EtabsMethods.GetSlabThickness(activeModel, wallName)));
            }

            return walls;
        }

        //public static Shell CreateWall(EtabsAPI activeModel, string wallName)
        //{
        //    return new Wall()
        //    {
        //        PropertyName = wallName,
        //        PropertyModifiers = EtabsMethods.GetShellPropertyModifiers(activeModel, wallName),
        //        Material = EtabsMethods.GetWallMaterial(activeModel, wallName),
        //        SectionType = SectionType.Wall,
        //        Thickness = EtabsMethods.GetWallThickness(activeModel, wallName)
        //    };
        //}

        public static ObservableCollection<Column> CreateMultipleColumns(EtabsAPI activeModel, List<string> columnNames)
        {
            var columns = new ObservableCollection<Column>();

            foreach (var columnName in columnNames)
            {
                columns.Add(new Column(
                    columnName,
                    EtabsMethods.GetFramePropertyModifiers(activeModel, columnName),

                    );
            }

            return columns;
        }

        public static Column CreateColumn(EtabsAPI activeModel, string columnName)
        {
            return new Column()
            {
                PropertyName = columnName,
                PropertyModifiers = EtabsMethods.GetFramePropertyModifiers(activeModel, columnName),
                Material = EtabsMethods.GetFrameMaterial(activeModel, columnName),
                SectionType = SectionType.Column
            };
        }

        public static ObservableCollection<Beam> CreateBeams(EtabsAPI activeModel, List<string> beamNames)
        {
            var beams = new ObservableCollection<Beam>();

            foreach (var beamName in beamNames)
            {
                beams.Add(new Beam()
                {
                    PropertyName = beamName,
                    PropertyModifiers = EtabsMethods.GetFramePropertyModifiers(activeModel, beamName),
                    Material = EtabsMethods.GetFrameMaterial(activeModel, beamName),
                    SectionType = SectionType.Beam
                });
            }

            return beams;
        }

        public static bool WallsSynced(Wall wall, ObservableCollection<Wall> listOfWalls)
        {
            if(listOfWalls != null)
            {
                string sectionName = wall.StripSectionName(wall.PropertyName);

                var matches = listOfWalls.Where(w => w.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool SlabsSynced(Slab slab, ObservableCollection<Slab> listOfSlabs)
        {
            if (listOfSlabs != null)
            {
                string sectionName = slab.StripSectionName(slab.PropertyName);

                var matches = listOfSlabs.Where(w => w.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool DropsSynced(DropPanel dropPanel, ObservableCollection<DropPanel> listOfDropPanels)
        {
            if (listOfDropPanels != null)
            {
                string sectionName = dropPanel.StripSectionName(dropPanel.PropertyName);

                var matches = listOfDropPanels.Where(w => w.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool ColumnsSynced(Column column, ObservableCollection<Column> listOfColumns)
        {
            if (listOfColumns != null)
            {
                string sectionName = column.StripSectionName(column.PropertyName);

                var matches = listOfColumns.Where(w => w.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool BeamsSynced(Beam beam, ObservableCollection<Beam> listOfBeams)
        {
            if (listOfBeams != null)
            {
                string sectionName = beam.StripSectionName(beam.PropertyName);

                var matches = listOfBeams.Where(w => w.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }
    }
}
