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

            foreach (var slabName in slabNames)
            {
                slabs.Add(new Slab()
                {
                    PropertyName = slabName,
                    PropertyModifiers = EtabsMethods.GetShellPropertyModifiers(activeModel, slabName),
                    Material = EtabsMethods.GetSlabMaterial(activeModel, slabName),
                    SectionType = SectionType.Slab,
                    Thickness = EtabsMethods.GetSlabThickness(activeModel, slabName)
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
                    Material = EtabsMethods.GetSlabMaterial(activeModel, dropName),
                    SectionType = SectionType.Drop,
                    Thickness = EtabsMethods.GetSlabThickness(activeModel, dropName)
                });
            }

            return drops;
        }

        public static ObservableCollection<Shell> CreateWalls(EtabsAPI activeModel, List<string> wallNames)
        {
            var walls = new ObservableCollection<Shell>();

            foreach (var wallName in wallNames)
            {
                walls.Add(CreateWall(activeModel, wallName));
            }

            return walls;
        }

        public static Shell CreateWall(EtabsAPI activeModel, string wallName)
        {
            return new Wall()
            {
                PropertyName = wallName,
                PropertyModifiers = EtabsMethods.GetShellPropertyModifiers(activeModel, wallName),
                Material = EtabsMethods.GetWallMaterial(activeModel, wallName),
                SectionType = SectionType.Wall,
                Thickness = EtabsMethods.GetWallThickness(activeModel, wallName)
            };
        }

        public static ObservableCollection<Section> CreateColumns(EtabsAPI activeModel, List<string> columnNames)
        {
            var columns = new ObservableCollection<Section>();

            foreach (var columnName in columnNames)
            {
                columns.Add(CreateColumn(activeModel, columnName));
            }

            return columns;
        }

        public static Section CreateColumn(EtabsAPI activeModel, string columnName)
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

        public static bool ElementSynced(Section section, ObservableCollection<Section> listOfSections)
        {

            string sectionName = section.GetSectionName(section.PropertyName);

            var matches = listOfSections.Where(w => w.PropertyName == sectionName);

            return matches.Count() > 0;

        }

        public static bool ElementSynced(Shell section, ObservableCollection<Shell> listOfSections)
        {

            string sectionName = section.GetSectionName(section.PropertyName);

            var matches = listOfSections.Where(w => w.PropertyName == sectionName);

            return matches.Count() > 0;

        }
    }
}
