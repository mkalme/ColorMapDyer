using System;
using System.Drawing;

namespace ColorMapDyer {
    static class ColorExtensions {
        public static Color SetBrightness(this Color color, float brightness) {
            int r = (int)(color.R * brightness);
            int g = (int)(color.G * brightness);
            int b = (int)(color.B * brightness);

            return Color.FromArgb(r, g, b);
        }
    }
}
