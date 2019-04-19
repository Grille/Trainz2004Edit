using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace TRS2004Edit
{
    public partial class TrainzButton : UserControl
    {
        private int mouseState = 0;
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        public override String Text { get; set; }
        [Browsable(false)]
        public override Color ForeColor { get; set; }
        public TrainzButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            Bitmap lamp;
            switch (mouseState)
            {
                case 1: lamp = (Bitmap)Properties.Resources.ResourceManager.GetObject("lampY"); break;
                case 2: lamp = (Bitmap)Properties.Resources.ResourceManager.GetObject("lampG"); break;
                default: lamp = (Bitmap)Properties.Resources.ResourceManager.GetObject("lamp"); break;
            }
            g.DrawImage(lamp, new Rectangle(0, 0, Height, Height), new Rectangle(0, 0, 32, 32), GraphicsUnit.Point);
            var format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            var rect = new RectangleF(40, 0, Width, 32);
            Bitmap text = new Bitmap((int)rect.Width, (int)rect.Height);
            var ig = Graphics.FromImage(text);
            ig.DrawString(Text, Font, new SolidBrush(ForeColor), rect, format);
            ig.Dispose();
            //var blur = Blur(text, new Rectangle(0, 0, text.Width, text.Height), 5);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), rect, format);
            //g.DrawImage(blur, rect, new Rectangle(0, 0, blur.Width, blur.Height), GraphicsUnit.Point);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseState = 1;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseState = 0;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseState = 2;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseState = 0;
            this.Invalidate();
        }

        private static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            Bitmap blurred = new Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                        for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                            blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurred;
        }
    }
}
