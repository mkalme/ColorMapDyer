using System;
using System.Drawing;
using System.Windows.Forms;
using ColorMapDyer;

namespace GUI {
    public partial class Window : Form {
        private DyeProcessor Processor = new DyeProcessor();
        private Image Image { get; set; }

        public Window()
        {
            InitializeComponent();

            SetImage();
            DisplayImage(Image);
        }

        private void SetImage() {
            Image image = Image.FromFile(@"Assets\grass_block_top.png");

            Image = Processor.DyeBitmap(new Bitmap(image), ColorTranslator.FromHtml("#90814d"));

            Console.WriteLine(ColorTranslator.ToHtml(new Bitmap(Image).GetAverageColor()));

            Point p = ColorMaps.Grass.GetColorLocation(ColorTranslator.FromHtml("#90814d"));
            //Console.WriteLine($"{p.X}, {p.Y}");

            Clipboard.SetImage(Image);
        }
        private void DisplayImage(Image image){
            Size size = PictureBox.Size.GetSizeInRatio(image.Size);

            PictureBox.Image = image.Resize(size);
        }

        private void PictureBox_SizeChanged(object sender, EventArgs e)
        {
            DisplayImage(Image);
        }
    }
}
