using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ2MapTools
{
    public partial class DrawingBox : PictureBox
    {

        // required by PictureBox
        public AutoScaleMode AutoScaleMode;

        RectangleF linesRect = new RectangleF();

        public DrawingBox()
        {
            InitializeComponent();
        }

        public void SetOutline(int width, int height)
        {
            if (height > width)
            {
                this.Height = 100;
                this.Width = width / (height / 100);
            }
            else if (width > height)
            {
                this.Width = 100;
                this.Height = height / (width / 100);
            }
            else
            {
                this.Width = 100;
                this.Height = 100;
            }
        }

        public void SetAvailaleRect(double[] zonerect, double[] availablerect)
        {
            // zonerect
            RectangleF areaRect = new RectangleF();
            areaRect.X = (float)zonerect[0];
            areaRect.Y = (float)zonerect[1];
            areaRect.Width = (float)(zonerect[2] - zonerect[0]);
            areaRect.Height = (float)(zonerect[3] - zonerect[1]);

            // availablerect
            RectangleF svgRect = new RectangleF();
            svgRect.X = (float)availablerect[0];
            svgRect.Y = (float)availablerect[1];
            svgRect.Width = (float)(availablerect[2] - availablerect[0]);
            svgRect.Height = (float)(availablerect[3] - availablerect[1]);
            // move it so it starts a 0,0
            svgRect.Offset(areaRect.X * -1, areaRect.Y * -1);

            // scale and position the availablerect so it fits in our picturebox
            float zwppp = areaRect.Width / this.Width;
            float zhppp = areaRect.Height / this.Height;
            linesRect.X = svgRect.X / zwppp;
            linesRect.Y = svgRect.Y / zhppp;
            linesRect.Width = svgRect.Width / zwppp;
            linesRect.Height = svgRect.Height / zhppp;
            this.Invalidate();
        }

        public void ClearLines()
        {
            linesRect.X = 0;
            linesRect.Y = 0;
            linesRect.Width = 0;
            linesRect.Height = 0;
            this.Invalidate(true);
        }

        private void DrawingBox_Paint(object sender, PaintEventArgs e)
        {
            if(Properties.Resources.background != null)
            {
                // paint the background
                Image image = new Bitmap(Properties.Resources.background);
                TextureBrush tb = new TextureBrush(image);
                // transform the original image to our widthxheight
                float xscale = (float)this.Width / (float)image.Width;
                float yscale = (float)this.Height / (float)image.Height;
                tb.ScaleTransform(xscale, yscale);
                e.Graphics.FillRectangle(tb, new Rectangle(0, 0, this.Width, this.Height));
            }
            // paint the lines area
            HatchBrush hb = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black, Color.Transparent);
            e.Graphics.FillRectangle(hb, linesRect);
        }
    }
}
