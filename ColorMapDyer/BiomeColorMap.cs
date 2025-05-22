using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ColorMapDyer {
    public class BiomeColorMap {
        public Bitmap ColorMap { get; set; } = ColorMaps.Grass;

        public Dictionary<string, Color> BiomeDictionary = new Dictionary<string, Color>() {
            //{"minecraft:badlands", ColorMap.GetPixel()}
        };
    }
}
