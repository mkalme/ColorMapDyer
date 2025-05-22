using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GUI {
    static class Extensions {
        public static Image Resize(this Image image, Size size)
        {
            int width = size.Width;
            int height = size.Height;

            if (width == 0 || height == 0) return image;

            Bitmap output = new Bitmap(image, width, height);

            using (Graphics g = Graphics.FromImage(output)) {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(image, 0, 0, width, height);
            }

            return output;
        }
        public static Size GetSizeInRatio(this Size containerSize, Size size){
            float width = containerSize.Width;
            float height = size.Height * (containerSize.Width / (float)size.Width);

            if (height > containerSize.Height) {
                float r = containerSize.Height / height;

                width *= r;
                height *= r;
            }

            return new Size((int)width, (int)height);
        }

        public static Color GetAverageColor(this Bitmap bitmap) {
            float rf = 0;
            float gf = 0;
            float bf = 0;

            float c = 0;
            for (int y = 0; y < bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    Color color = bitmap.GetPixel(x, y);

                    if (color.A == 0) continue;

                    rf += color.R;
                    gf += color.G;
                    bf += color.B;

                    c++;
                }
            }

            int r = (int)(rf / c);
            int g = (int)(gf / c);
            int b = (int)(bf / c);

            ClampColor(ref r, ref g, ref b);

            return Color.FromArgb(r, g, b);
        }
        private static void ClampColor(ref int r, ref int g, ref int b){
            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;

            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;
        }

        public static Point GetColorLocation(this Bitmap bitmap, Color color) {
            for (int y = 0; y < bitmap.Height; y++) {
                for (int x = 0; x < bitmap.Width; x++) {
                    if (bitmap.GetPixel(x, y) == color) return new Point(x, y);
                }
            }

            return new Point(-1, -1);
        }
    }
}
