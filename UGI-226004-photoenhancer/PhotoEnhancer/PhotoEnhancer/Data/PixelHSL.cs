﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public struct PixelHSL
    {
        private double h;
        public double H
        {
            get => h;
            set => h = CheckValue(value);
        }

        private double s;
        public double S
        {
            get => s;
            set => s = CheckValue(value);
        }

        private double l;
        public double L
        {
            get => l;
            set => l = CheckValue(value);
        }

        public PixelHSL(double hue, double saturation, double lightness) : this()
        {
            H = hue;
            S = saturation;
            L = lightness;
        }

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new ArgumentException("Неверное значение для интенсивности канала");

            return val;
        }


        public static double Trim(double channel)
        {
            if (channel < 0) return 0;

            if (channel > 1) return 1;

            return channel;
        }

    }
}
