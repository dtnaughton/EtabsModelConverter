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
        public static ObservableCollection<Slab> CreateSlabs(EtabsAPI activeModel, List<string> slabNames)
        {
            var slabs = new ObservableCollection<Slab>();

            foreach(var slabName in slabNames)
            {
                slabs.Add(new Slab()
                {
                    PropertyName = slabName,
                    PropertyModifiers = EtabsMethods.GetShellPropertyModifiers(activeModel, slabName),
                    Material = EtabsMethods.GetShellMaterial(activeModel, slabName),
                    SectionType = SectionType.Slab
                });
            }

            return slabs;
        }
        public static ObservableCollection<DropPanel> CreateDrops(EtabsAPI activeModel, List<string> dropNames)
        {
            var drops = new ObservableCollection<DropPanel>();

            foreach (var dropName in dropNames)
            {
                drops.Add(new DropPanel()
                {
                    PropertyName = dropName,
                    PropertyModifiers = EtabsMethods.GetShellPropertyModifiers(activeModel, dropName),
                    Material = EtabsMethods.GetShellMaterial(activeModel, dropName),
                    SectionType = SectionType.Drop
                });
            }

            return drops;
        }

        public static ObservableCollection<Wall> CreateWalls(EtabsAPI activeModel, List<string> wallNames)
        {
            var walls = new ObservableCollection<Wall>();

            foreach (var wallName in wallNames)
            {
                walls.Add(new Wall()
                {
                    PropertyName = wallName,
                    PropertyModifiers = EtabsMethods.GetShellPropertyModifiers(activeModel, wallName),
                    Material = EtabsMethods.GetShellMaterial(activeModel, wallName),
                    SectionType = SectionType.Wall
                });
            }

            return walls;
        }

        public static ObservableCollection<Column> CreateColumns(EtabsAPI activeModel, List<string> columnNames)
        {
            var columns = new ObservableCollection<Column>();

            foreach(var columnName in columnNames)
            {
                columns.Add(new Column()
                {
                    PropertyName = columnName,
                    PropertyModifiers = EtabsMethods.GetFramePropertyModifiers(activeModel, columnName),
                    Material = EtabsMethods.GetFrameMaterial(activeModel, columnName),
                    SectionType = SectionType.Column
                });
            }

            return columns;
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

    }
}
