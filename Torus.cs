using Avalonia;
using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public class Torus : Shape3D, IDrawable, IMeasurable3D
    {
        [JsonProperty]
        public int MajorRadius { get; protected set; }
        [JsonProperty]
        public int MinorRadius { get; protected set; }
        public double SurfaceArea => 4 * Math.Pow(Math.PI, 2) * this.MajorRadius * this.MinorRadius;
        public double Volume => 2 * Math.Pow(Math.PI, 2) * this.MajorRadius * Math.Pow(this.MinorRadius, 2);

        public Torus(int x, int y, int z, int majorR, int minorR, ShapeColors? c = null) : base(x, y, z, c)
        {
            this.MajorRadius = majorR >= 0 ? majorR : 0;
            this.MinorRadius = minorR >= 0 ? minorR : 0;
        }

        public override void Resize(ShapeGeometry geometry)
        {
            this.MajorRadius = geometry.Width >= 0 ? geometry.Width : 0;
            this.MinorRadius = geometry.Depth >= 0 ? geometry.Depth : 0;
        }

        public void Draw(DrawingContext context)
        {
            byte[] color = ColorConverter.SplitToChannels((uint)this.Color);
            Color avaloniaColor = new(color[3], color[0], color[1], color[2]);

            double flatten = 0.5;

            double outerRx = this.MajorRadius + this.MinorRadius;
            double outerRy = outerRx * flatten;

            double innerRx = this.MajorRadius - this.MinorRadius;
            double innerRy = innerRx * flatten;

            EllipseGeometry outerEllipse = new(new Rect(this.X - outerRx, this.Y - outerRy, outerRx * 2, outerRy * 2));
            EllipseGeometry innerEllipse = new(new Rect(this.X - innerRx, this.Y - innerRy, innerRx * 2, innerRy * 2));

            CombinedGeometry torusGeometry = new(GeometryCombineMode.Exclude, outerEllipse, innerEllipse);

            IBrush fillBrush = new SolidColorBrush(avaloniaColor);
            IPen borderPen = new Pen(Brushes.Black, 1.5);

            context.DrawGeometry(fillBrush, borderPen, torusGeometry);
        }
    }
}
