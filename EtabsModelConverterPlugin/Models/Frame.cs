﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;


namespace EtabsModelConverterPlugin.Models
{
    public class Frame : Section, IFrame
    {
        public FramePropertyModifiers PropertyModifiers { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Frame(string propertyName, FramePropertyModifiers framePropertyModifiers, IMaterial material, double width, double height) : base(propertyName, material)
        {
            PropertyModifiers = framePropertyModifiers;
            Width = width;
            Height = height;
        }
    }
}