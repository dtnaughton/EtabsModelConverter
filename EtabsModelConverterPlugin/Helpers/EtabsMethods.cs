using EtabsModelConverterPlugin.Models;
using ETABSv1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EtabsModelConverterPlugin.Helpers
{
    public class EtabsMethods
    {
        public static List<string> GetSlabNames(EtabsAPI activeModel)
        {
            int numberOfAreas = 0;
            string[] areaNames = new string[1];

            activeModel.SapModel.PropArea.GetNameList(ref numberOfAreas, ref areaNames);

            var slabNames = new List<string>();

            foreach (var name in areaNames)
            {
                if (name.ToLower().StartsWith("s") && VerifySlabAssignment(activeModel, name))
                {
                    slabNames.Add(name);
                }
            }

            return slabNames;
        }
        public static List<string> GetWallNames(EtabsAPI activeModel)
        {
            int numberOfAreas = 0;
            string[] areaNames = new string[1];

            activeModel.SapModel.PropArea.GetNameList(ref numberOfAreas, ref areaNames);

            var wallNames = new List<string>();

            foreach (var name in areaNames)
            {
                if (name.ToLower().StartsWith("w") && VerifyWallAssignment(activeModel, name))
                {
                    wallNames.Add(name);
                }
            }

            return wallNames;
        }
        public static List<string> GetDropNames(EtabsAPI activeModel)
        {
            int numberOfAreas = 0;
            string[] areaNames = new string[1];

            activeModel.SapModel.PropArea.GetNameList(ref numberOfAreas, ref areaNames);

            var dropNames = new List<string>();

            foreach (var name in areaNames)
            {
                if (name.ToLower().StartsWith("d") && VerifyDropAssignment(activeModel, name))
                {
                    dropNames.Add(name);
                }
            }

            return dropNames;
        }
        public static List<string> GetBeamNames(EtabsAPI activeModel)
        {
            int numberOfFrames = 0;
            string[] frameNames = new string[1];

            activeModel.SapModel.PropFrame.GetNameList(ref numberOfFrames, ref frameNames);

            var beamNames = new List<string>();

            foreach (var name in frameNames)
            {
                if (name.ToLower().StartsWith("b"))
                {
                    beamNames.Add(name);
                }
            }

            return beamNames;
        }
        public static List<string> GetColumnNames(EtabsAPI activeModel)
        {
            int numberOfFrames = 0;
            string[] frameNames = new string[1];

            activeModel.SapModel.PropFrame.GetNameList(ref numberOfFrames, ref frameNames);

            var columnNames = new List<string>();

            foreach (var name in frameNames)
            {
                if (name.ToLower().StartsWith("c"))
                {
                    columnNames.Add(name);
                }
            }

            return columnNames;
        }
        public static List<string> FilterNames(List<string> names, string limitState)
        {
            var filteredNames = new List<string>();

            if (limitState.Equals("ULS"))
            {
                foreach (var name in names)
                {
                    if (IsPropertyULS(name))
                    {
                        filteredNames.Add(name);
                    }
                }
            }

            else
            {
                foreach (var name in names)
                {
                    if (IsPropertySLS(name))
                    {
                        filteredNames.Add(name);
                    }
                }
            }

            return filteredNames;
        }

        public static ShellPropertyModifiers GetShellPropertyModifiers(EtabsAPI activeModel, string shellName)
        {
            double[] propertyModifiers = new double[1];

            activeModel.SapModel.PropArea.GetModifiers(shellName, ref propertyModifiers);

            return new ShellPropertyModifiers()
            {
                F11 = propertyModifiers[0],
                F22 = propertyModifiers[1],
                F12 = propertyModifiers[2],
                M11 = propertyModifiers[3],
                M22 = propertyModifiers[4],
                M12 = propertyModifiers[5],
                V13 = propertyModifiers[6],
                V23 = propertyModifiers[7],
                Mass = propertyModifiers[8],
                Weight = propertyModifiers[9]
            };
        }
        public static FramePropertyModifiers GetFramePropertyModifiers(EtabsAPI activeModel, string frameName)
        {
            double[] propertyModifiers = new double[1];

            activeModel.SapModel.PropFrame.GetModifiers(frameName, ref propertyModifiers);

            return new FramePropertyModifiers()
            {
                CrossSectionalArea = propertyModifiers[0],
                ShearArea2Direction = propertyModifiers[1],
                ShearArea3Direction = propertyModifiers[2],
                TorsionalConstant = propertyModifiers[3],
                MomentOfInertiaAbout2 = propertyModifiers[4],
                MomentOfInertiaAbout3 = propertyModifiers[5],
                Mass = propertyModifiers[6],
                Weight = propertyModifiers[7],
            };
        }

        public static IMaterial GetSlabMaterial(EtabsAPI activeModel, string shellName)
        {
            eSlabType slabType = new eSlabType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetSlab(shellName, ref slabType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return new ConcreteMaterial() { Name = materialPropertyName };
        }
        public static IMaterial GetWallMaterial(EtabsAPI activeModel, string shellName)
        {
            eWallPropType wallType = new eWallPropType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetWall(shellName, ref wallType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return new ConcreteMaterial() { Name = materialPropertyName };
        }

        public static IMaterial GetFrameMaterial(EtabsAPI activeModel, string frameName)
        {
            string materialPropertyName = "";

            activeModel.SapModel.PropFrame.GetMaterial(frameName, ref materialPropertyName);

            return new ConcreteMaterial() { Name = materialPropertyName };
        }

        public static Geometry GetFrameGeometry(EtabsAPI activeModel, string frameName, ColumnType columnType)
        {
            string fileName, matProp, notes, gUID;
            double t3, t2;
            int color = 0;

            fileName = matProp = notes = gUID = "";
            t3 = t2 = 0;

            if (columnType == ColumnType.Circle)
            {
                activeModel.SapModel.PropFrame.GetCircle(frameName, ref fileName, ref matProp, ref t3, ref color, ref notes, ref gUID);
            }

            else
            {
                activeModel.SapModel.PropFrame.GetRectangle(frameName, ref fileName, ref matProp, ref t3, ref t2, ref color, ref notes, ref gUID);
            }

            return new Geometry() { Height = t2, Width = t3 };
        }

        public static double GetSlabThickness(EtabsAPI activeModel, string shellName)
        {
            eSlabType slabType = new eSlabType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetSlab(shellName, ref slabType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return materialThickness;
        }

        public static double GetWallThickness(EtabsAPI activeModel, string shellName)
        {
            eWallPropType wallType = new eWallPropType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetWall(shellName, ref wallType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return materialThickness;
        }

        public static bool IsPropertyULS(string name)
        {
            string[] words = name.Split('-');

            // Returns true if naming convention followed e.g. W200-ULS
            return name.Split('-').Last().ToLower().StartsWith("u");
        }

        public static bool IsPropertySLS(string name)
        {
            string[] words = name.Split('-');

            // Returns true if naming convention followed e.g. W200-SLS
            return words.Length == 1 ? false : name.Split('-').Last().ToLower().StartsWith("s");
        }

        /// <summary>
        /// Determines if column is rectangular or circular
        /// </summary>
        /// <param name="activeModel"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static ColumnType GetColumnType(EtabsAPI activeModel, string columnName)
        {
            eFramePropType columnType = new eFramePropType();

            activeModel.SapModel.PropFrame.GetTypeOAPI(columnName, ref columnType);

            return columnType == eFramePropType.Circle ? ColumnType.Circle : ColumnType.Rectangle;
        }

        // Verify that user assignment of slab is correct and there is no discrepancy between naming slab convention and property assignment
        public static bool VerifySlabAssignment(EtabsAPI activeModel, string areaName)
        {
            eSlabType slabType = new eSlabType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetSlab(areaName, ref slabType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return slabType == eSlabType.Slab;
        }

        public static bool VerifyDropAssignment(EtabsAPI activeModel, string areaName)
        {
            eSlabType slabType = new eSlabType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetSlab(areaName, ref slabType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return slabType == eSlabType.Drop;
        }

        public static bool VerifyWallAssignment(EtabsAPI activeModel, string areaName)
        {
            eWallPropType wallType = new eWallPropType();
            eShellType shellType = new eShellType();
            string materialPropertyName = "";
            double materialThickness = 0;
            int materialColor = 0;
            string notes = "";
            string gUID = "";

            activeModel.SapModel.PropArea.GetWall(areaName, ref wallType, ref shellType, ref materialPropertyName, ref materialThickness, ref materialColor, ref notes, ref gUID);

            return wallType == eWallPropType.AutoSelectList || wallType == eWallPropType.Specified;
        }

        public static bool AreUlsPropertiesApplied(EtabsAPI activeModel)
        {
            int numberOfAreas, numberOfBoundaryPts;
            string[] areaNames, pointNames;
            eAreaDesignOrientation[] designOrientation = new eAreaDesignOrientation[1];
            int[] pointDelimiter;
            double[] pointX, pointY, pointZ;

            numberOfAreas = numberOfBoundaryPts = 0;
            areaNames = pointNames = new string[1];
            pointDelimiter = new int[1];
            pointX = pointY = pointZ = new double[1];

            activeModel.SapModel.AreaObj.GetAllAreas(ref numberOfAreas, ref areaNames, ref designOrientation, ref numberOfBoundaryPts, ref pointDelimiter, ref pointNames, ref pointX, ref pointY, ref pointZ);



            if (numberOfAreas > 0)
            {
                string propName = "";

                activeModel.SapModel.AreaObj.GetProperty(areaNames.FirstOrDefault(), ref propName);

                return IsPropertyULS(propName);
            }

            // No areas in model, check for columns
            else if (numberOfAreas == 0)
            {
                List<Column> columns = GetAssignedColumnsInModel(activeModel);

                if(columns.Count() != 0)
                {
                    return IsPropertyULS(columns.FirstOrDefault().PropertyName);
                }
                
                // No columns in model, check for beams
                else
                {
                    List<Beam> beams = GetAssignedBeamsInModel(activeModel);

                    return beams != null ? IsPropertyULS(beams.FirstOrDefault().PropertyName) : false;
                }
            }

            else
            {
                return false;
            }
        }

        public static void CreateWallElementInETABS(EtabsAPI activeModel, ObservableCollection<Wall> wallsToAdd)
        {
            foreach (var wall in wallsToAdd)
            {
                activeModel.SapModel.PropArea.SetWall(wall.PropertyName, eWallPropType.AutoSelectList, eShellType.ShellThin, wall.Material.Name, wall.Thickness);
            }
        }

        public static void CreateSlabElementInETABS(EtabsAPI activeModel, ObservableCollection<Slab> slabsToAdd)
        {
            foreach (var slab in slabsToAdd)
            {
                activeModel.SapModel.PropArea.SetSlab(slab.PropertyName, eSlabType.Slab, eShellType.ShellThin, slab.Material.Name, slab.Thickness);
            }
        }

        public static void CreateDropElementInETABS(EtabsAPI activeModel, ObservableCollection<DropPanel> dropsToAdd)
        {
            foreach (var drop in dropsToAdd)
            {
                activeModel.SapModel.PropArea.SetSlab(drop.PropertyName, eSlabType.Drop, eShellType.ShellThin, drop.Material.Name, drop.Thickness);
            }
        }

        public static void CreateBeamElementInETABS(EtabsAPI activeModel, ObservableCollection<Beam> framesToAdd)
        {
            foreach (var frame in framesToAdd)
            {
                int i = activeModel.SapModel.PropFrame.SetRectangle(frame.PropertyName, frame.Material.Name, frame.Geometry.Height, frame.Geometry.Width);
            }
        }

        public static void CreateColumnElementInETABS(EtabsAPI activeModel, ObservableCollection<Column> framesToAdd)
        {
            foreach (var frame in framesToAdd)
            {
                int i = activeModel.SapModel.PropFrame.SetRectangle(frame.PropertyName, frame.Material.Name, frame.Geometry.Height, frame.Geometry.Width);
            }
        }

        public static void AssignPropertiesToEtabs(EtabsAPI activeModel, ObservableCollection<Beam> beams, ObservableCollection<Column> columns, ObservableCollection<Slab> slabs, ObservableCollection<DropPanel> dropPanels, ObservableCollection<Wall> walls)
        {
            AssignFramesToEtabs(activeModel, beams, columns);
            AssignAreasToEtabs(activeModel, slabs, dropPanels, walls);
        }

        public static void AssignFramesToEtabs(EtabsAPI activeModel, ObservableCollection<Beam> beams, ObservableCollection<Column> columns)
        {
            int numberOfFrames = 0;
            string[] frameNames, propertyNames, storyNames, point1Names, point2Names;
            frameNames = propertyNames = storyNames = point1Names = point2Names = new string[1];
            double[] point1x, point1y, point1z, point2x, point2y, point2z, angle, offset1x, offset2x, offset1y, offset2y, offset1z, offset2z;
            point1x = point1y = point1z = point2x = point2y = point2z = angle = offset1x = offset2x = offset1y = offset2y = offset1z = offset2z = new double[1];
            int[] cardinalPoints = new int[1];

            activeModel.SapModel.FrameObj.GetAllFrames(ref numberOfFrames, ref frameNames, ref propertyNames, ref storyNames, ref point1Names, ref point2Names, ref point1x, ref point1y, ref point1z, ref point2x, ref point2y, ref point2z, ref angle, ref offset1x, ref offset2x, ref offset1y, ref offset2y, ref offset1z, ref offset2z, ref cardinalPoints);

            for (int i = 0; i < numberOfFrames; i++)
            {
                if (propertyNames[i].ToLower().StartsWith("b"))
                {
                    List<Beam> matchingBeams = new List<Beam>();

                    foreach (var beam in beams)
                    {
                        if (Section.StripSectionName(beam.PropertyName) == Section.StripSectionName(propertyNames[i]))
                        {
                            matchingBeams.Add(beam);
                        }
                    }

                    // If ULS and SLS sections not synced, list will not populate
                    if (matchingBeams.Count() == 0)
                    {
                        MessageBox.Show("Section is not defined. Ensure sections are synced.");
                        return;
                    }

                    activeModel.SapModel.FrameObj.SetSection(frameNames[i], matchingBeams.FirstOrDefault().PropertyName);
                }

                else
                {
                    List<Column> matchingColumns = new List<Column>();

                    foreach (var column in columns)
                    {
                        if (Section.StripSectionName(column.PropertyName) == Section.StripSectionName(propertyNames[i]))
                        {
                            matchingColumns.Add(column);
                        }
                    }

                    // If ULS and SLS sections not synced, list will not populate
                    if (matchingColumns.Count() == 0)
                    {
                        MessageBox.Show("Section is not defined. Ensure sections are synced.");
                        return;
                    }

                    activeModel.SapModel.FrameObj.SetSection(frameNames[i], matchingColumns.FirstOrDefault().PropertyName);
                }
            }
        }

        public static void AssignAreasToEtabs(EtabsAPI activeModel, ObservableCollection<Slab> slabs, ObservableCollection<DropPanel> dropPanels, ObservableCollection<Wall> walls)
        {
            int numberOfAreas, numberOfBoundaryPts;
            string[] areaNames, pointNames;
            eAreaDesignOrientation[] designOrientation = new eAreaDesignOrientation[1];
            int[] pointDelimiter;
            double[] pointX, pointY, pointZ;

            numberOfAreas = numberOfBoundaryPts = 0;
            areaNames = pointNames = new string[1];
            pointDelimiter = new int[1];
            pointX = pointY = pointZ = new double[1];

            activeModel.SapModel.AreaObj.GetAllAreas(ref numberOfAreas, ref areaNames, ref designOrientation, ref numberOfBoundaryPts, ref pointDelimiter, ref pointNames, ref pointX, ref pointY, ref pointZ);

            for (int i = 0; i < numberOfAreas; i++)
            {
                string propertyName = "";
                activeModel.SapModel.AreaObj.GetProperty(areaNames[i], ref propertyName);

                if (propertyName.ToLower().StartsWith("s"))
                {
                    List<Slab> matchingSlabs = new List<Slab>();

                    foreach(var slab in slabs)
                    {
                        if(Section.StripSectionName(slab.PropertyName) == Section.StripSectionName(propertyName))
                        {
                            matchingSlabs.Add(slab);
                        }
                    }
                    activeModel.SapModel.AreaObj.SetProperty(areaNames[i], matchingSlabs.FirstOrDefault().PropertyName);
                }

                else if (propertyName.ToLower().StartsWith("d"))
                {
                    List<DropPanel> matchingDrops = new List<DropPanel>();

                    foreach (var drop in dropPanels)
                    {
                        if (Section.StripSectionName(drop.PropertyName) == Section.StripSectionName(propertyName))
                        {
                            matchingDrops.Add(drop);
                        }
                    }
                    activeModel.SapModel.AreaObj.SetProperty(areaNames[i], matchingDrops.FirstOrDefault().PropertyName);
                }

                else
                {
                    List <Wall> matchingWalls = new List<Wall>();

                    foreach (var wall in walls)
                    {
                        if (Section.StripSectionName(wall.PropertyName) == Section.StripSectionName(propertyName))
                        {
                            matchingWalls.Add(wall);
                        }
                    }
                    activeModel.SapModel.AreaObj.SetProperty(areaNames[i], matchingWalls.FirstOrDefault().PropertyName);
                }
            }
        }

        public static List<Beam> GetAssignedBeamsInModel(EtabsAPI activeModel)
        {
            int numberOfFrames = 0;
            string[] frameNames, propertyNames, storyNames, point1Names, point2Names;
            frameNames = propertyNames = storyNames = point1Names = point2Names = new string[1];
            double[] point1x, point1y, point1z, point2x, point2y, point2z, angle, offset1x, offset2x, offset1y, offset2y, offset1z, offset2z;
            point1x = point1y = point1z = point2x = point2y = point2z = angle = offset1x = offset2x = offset1y = offset2y = offset1z = offset2z = new double[1];
            int[] cardinalPoints = new int[1];

            activeModel.SapModel.FrameObj.GetAllFrames(ref numberOfFrames, ref frameNames, ref propertyNames, ref storyNames, ref point1Names, ref point2Names, ref point1x, ref point1y, ref point1z, ref point2x, ref point2y, ref point2z, ref angle, ref offset1x, ref offset2x, ref offset1y, ref offset2y, ref offset1z, ref offset2z, ref cardinalPoints);

            List<Beam> beams = new List<Beam>();

            for (int i = 0; i < numberOfFrames; i++)
            {
                if (propertyNames[i].ToLower().StartsWith("b"))
                {
                    beams.Add(new Beam(
                    frameNames[i],
                    propertyNames[i]
                    ));
                }
            }

            return beams;
        }

        public static List<Column> GetAssignedColumnsInModel(EtabsAPI activeModel)
        {
            int numberOfFrames = 0;
            string[] frameNames, propertyNames, storyNames, point1Names, point2Names;
            frameNames = propertyNames = storyNames = point1Names = point2Names = new string[1];
            double[] point1x, point1y, point1z, point2x, point2y, point2z, angle, offset1x, offset2x, offset1y, offset2y, offset1z, offset2z;
            point1x = point1y = point1z = point2x = point2y = point2z = angle = offset1x = offset2x = offset1y = offset2y = offset1z = offset2z = new double[1];
            int[] cardinalPoints = new int[1];

            activeModel.SapModel.FrameObj.GetAllFrames(ref numberOfFrames, ref frameNames, ref propertyNames, ref storyNames, ref point1Names, ref point2Names, ref point1x, ref point1y, ref point1z, ref point2x, ref point2y, ref point2z, ref angle, ref offset1x, ref offset2x, ref offset1y, ref offset2y, ref offset1z, ref offset2z, ref cardinalPoints);

            List<Column> columns = new List<Column>();

            for (int i = 0; i < numberOfFrames; i++)
            {
                if (propertyNames[i].ToLower().StartsWith("c"))
                    {
                    columns.Add(new Column(
                    frameNames[i],
                    propertyNames[i]
                    ));
                }
            }

            return columns;
        }
    }
}

