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
    public class Sphere : Shape3D, IDrawable, IMeasurable3D
    {
        [JsonProperty]
        public int Radius { get; protected set; }
        public double SurfaceArea => 4 * Math.PI * Math.Pow(this.Radius, 2);
        public double Volume => (4.0 / 3.0) * Math.PI * Math.Pow(this.Radius, 3);

        public Sphere(int x, int y, int z, int r, ShapeColors? c = null) : base(x, y, z, c)
        {
            this.Radius = r >= 0 ? r : 0;
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
            Color baseColor = new(color[3], color[0], color[1], color[2]);

            GradientStops gradientStops = [
                new GradientStop(Colors.White, 0.0),
                new GradientStop(baseColor, 0.55),
                new GradientStop(Colors.Black, 1)
            ];

            RadialGradientBrush gradient = new()
            {
                Center = new RelativePoint(0.3, 0.3, RelativeUnit.Relative),
                GradientOrigin = new RelativePoint(0.3, 0.3, RelativeUnit.Relative),
                GradientStops = gradientStops,
                RadiusX = new RelativeScalar(0.8, RelativeUnit.Relative),
                RadiusY = new RelativeScalar(0.8, RelativeUnit.Relative)
            };

            Point center = new(this.X, this.Y);
            context.DrawEllipse(gradient, null, center, this.Radius, this.Radius);
        }
    }
}
