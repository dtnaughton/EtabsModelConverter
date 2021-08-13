﻿using EtabsModelConverterPlugin.Models;
using ETABSv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(name.ToLower().StartsWith("s") && VerifySlabAssignment(activeModel, name))
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

            foreach(var name in frameNames)
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
        public static IMaterial GetShellMaterial(EtabsAPI activeModel, string shellName)
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

        public static IMaterial GetFrameMaterial(EtabsAPI activeModel, string frameName)
        {
            string materialPropertyName = "";

            activeModel.SapModel.PropFrame.GetMaterial(frameName, ref materialPropertyName);

            return new ConcreteMaterial() { Name = materialPropertyName };
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
    }
}