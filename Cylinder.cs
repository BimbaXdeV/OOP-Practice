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
        public short Radius { get; protected set; }
        [JsonProperty]
        public short Height { get; protected set; }
        public double SurfaceArea => 2 * Math.PI * this.Radius * (this.Radius + this.Height);
        public double Volume => Math.PI * Math.Pow(this.Radius, 2) * this.Height;

        public Cylinder(short x, short y, short z, short r, short h, ShapeColors? c = null) : base(x, y, z, c)
        {
            this.Radius = (short)(r >= 0 ? r : 0);
            this.Height = (short)(h >= 0 ? h : 0);
        }

        public override void Resize(ShapeGeometry geometry)
        {
            this.Radius = (short)(geometry.OuterRadius >= 0 ? geometry.OuterRadius : 0);
            this.Height = (short)(geometry.Height >= 0 ? geometry.Height : 0);
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
