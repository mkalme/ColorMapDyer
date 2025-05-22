using System;
using System.Drawing;

namespace ColorMapDyer
{
    public class DyeProcessor
    {
        public Bitmap ColorMap { get; set; } = ColorMaps.Grass;

        public Bitmap DyeBitmap(Bitmap bitmap, Color pxColor) {
            Bitmap output = new Bitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    output.SetPixel(x, y, pxColor.SetBrightness(bitmap.GetPixel(x, y).GetBrightness()));
                }
            }

            return output;
        }
    }
}
