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
                    EtabsMethods.GetWallMaterial(activeModel, wallName),
                    EtabsMethods.GetWallThickness(activeModel, wallName)));
            }

            return walls;
        }

        public static ObservableCollection<Column> CreateMultipleColumns(EtabsAPI activeModel, List<string> columnNames)
        {
            var columns = new ObservableCollection<Column>();

            foreach (var columnName in columnNames)
            {
                columns.Add(new Column(
                    columnName,
                    EtabsMethods.GetFramePropertyModifiers(activeModel, columnName),
                    EtabsMethods.GetFrameMaterial(activeModel, columnName),
                    EtabsMethods.GetFrameGeometry(activeModel, columnName, EtabsMethods.GetColumnType(activeModel, columnName)),
                    EtabsMethods.GetColumnType(activeModel, columnName)
                    ));
            }

            return columns;
        }


        public static ObservableCollection<Beam> CreateMultipleBeams(EtabsAPI activeModel, List<string> beamNames)
        {
            var beams = new ObservableCollection<Beam>();

            foreach (var beamName in beamNames)
            {
                beams.Add(new Beam(
                    beamName,
                    EtabsMethods.GetFramePropertyModifiers(activeModel, beamName),
                    EtabsMethods.GetFrameMaterial(activeModel, beamName),
                    EtabsMethods.GetFrameGeometry(activeModel, beamName, ColumnType.Rectangle)
                    ));
            }

            return beams;
        }

        public static bool WallsSynced(Wall wall, ObservableCollection<Wall> listOfWalls)
        {
            if(listOfWalls != null)
            {
                string sectionName = Section.StripSectionName(wall.PropertyName);

                var matches = listOfWalls.Where(w => Section.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool SlabsSynced(Slab slab, ObservableCollection<Slab> listOfSlabs)
        {
            if (listOfSlabs != null)
            {
                string sectionName = Section.StripSectionName(slab.PropertyName);

                var matches = listOfSlabs.Where(w => Section.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool DropsSynced(DropPanel dropPanel, ObservableCollection<DropPanel> listOfDropPanels)
        {
            if (listOfDropPanels != null)
            {
                string sectionName = Section.StripSectionName(dropPanel.PropertyName);

                var matches = listOfDropPanels.Where(w => Section.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool ColumnsSynced(Column column, ObservableCollection<Column> listOfColumns)
        {
            if (listOfColumns != null)
            {
                string sectionName = Section.StripSectionName(column.PropertyName);

                var matches = listOfColumns.Where(w => Section.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static bool BeamsSynced(Beam beam, ObservableCollection<Beam> listOfBeams)
        {
            if (listOfBeams != null)
            {
                string sectionName = Section.StripSectionName(beam.PropertyName);

                var matches = listOfBeams.Where(w => Section.StripSectionName(w.PropertyName) == sectionName);

                return matches.Count() > 0;
            }

            return true;
        }

        public static ObservableCollection<Wall> SortWalls(ObservableCollection<Wall> walls)
        {
            var obj = walls.OrderBy(x => x.Thickness);

            return new ObservableCollection<Wall>(obj);
        }

        public static ObservableCollection<Slab> SortSlabs(ObservableCollection<Slab> slabs)
        {
            var obj = slabs.OrderBy(x => x.Thickness);

            return new ObservableCollection<Slab>(obj);
        }
        public static ObservableCollection<DropPanel> SortDrops(ObservableCollection<DropPanel> drops)
        {
            var obj = drops.OrderBy(x => x.Thickness);

            return new ObservableCollection<DropPanel>(obj);
        }

        public static ObservableCollection<Column> SortColumns(ObservableCollection<Column> columns)
        {
            var obj = columns.OrderBy(x => x.Geometry.Width).ThenBy(y => y.Geometry.Height);

            return new ObservableCollection<Column>(obj);
        }

        public static ObservableCollection<Beam> SortBeams(ObservableCollection<Beam> beams)
        {
            var obj = beams.OrderBy(x => x.Geometry.Width).ThenBy(y => y.Geometry.Height);

            return new ObservableCollection<Beam>(obj);
        }
    }
}
