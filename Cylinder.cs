using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OOP_Practice
{
    public class Cylinder : Shape3D, IDrawable, IMeasurable3D
    {
        [JsonProperty]
        public int Radius { get; protected set; }
        [JsonProperty]
        public int Height { get; protected set; }
        public double SurfaceArea => 2 * Math.PI * this.Radius * (this.Radius + this.Height);
        public double Volume => Math.PI * Math.Pow(this.Radius, 2) * this.Height;

        public Cylinder(int x, int y, int z, int r, int h, ShapeColors? c = null) : base(x, y, z, c)
        {
            this.Radius = r >= 0 ? r : 0;
            this.Height = h >= 0 ? h : 0;
        }

        public override void Resize(ShapeGeometry geometry)
        {
            this.X = geometry.X >= 0 ? geometry.X : 0;
            this.Y = geometry.Y >= 0 ? geometry.Y : 0;
            this.Z = geometry.Z >= 0 ? geometry.Z : 0;
        }

        public void Draw(DrawingContext context)
        {
            byte[] color = ColorConverter.SplitToChannels((uint)this.Color);
            Color avaloniaColor = new(color[3], color[0], color[1], color[2]);
            
            IBrush brush = new SolidColorBrush(avaloniaColor);
            IPen pen = new Pen(Brushes.Black, 1.5);

            double ellipseHeight = this.Radius * 0.25;

            Point topCenter = new(this.X, this.Y - this.Height / 2);
            Point bottomCenter = new(this.X, this.Y + this.Height / 2);

            context.DrawEllipse(brush, pen, bottomCenter, this.Radius, ellipseHeight);

            Rect bodyRect = new(this.X - this.Radius, topCenter.Y, this.Radius * 2, this.Height);
            context.DrawRectangle(brush, null, bodyRect);

            context.DrawLine(pen, new Point(this.X - this.Radius, topCenter.Y), new Point(this.X - this.Radius, bottomCenter.Y));
            context.DrawLine(pen, new Point(this.X + this.Radius, topCenter.Y), new Point(this.X + this.Radius, bottomCenter.Y));

            context.DrawEllipse(brush, pen, topCenter, this.Radius, ellipseHeight);
        }
    }
}
