using System;
using System.Drawing;

namespace ColorMapDyer {
    public static class ColorMaps {
        public static Bitmap Grass = new Bitmap(Image.FromFile(@"Assets\GrassColorMap.png")); 
        public static Bitmap Foliage = new Bitmap(Image.FromFile(@"Assets\FoliageColorMap.png")); 
    }
}
