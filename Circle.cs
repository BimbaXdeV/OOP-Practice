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
    public class Circle : Shape2D, IDrawable, IMeasurable2D
    {
        [JsonProperty]
        public short Radius { get; protected set; }

        public virtual double Area => Math.PI * Math.Pow(this.Radius, 2);
        public virtual double Perimeter => 2 * Math.PI * this.Radius;

        public Circle(short x, short y, short r, ShapeColors? c = null) : base(x, y, c)
        {
            this.Radius = (short)(r >= 0 ? r : 0);
        }

        public override void Move(ShapeGeometry geometry)
        {
            base.Move(geometry);
        }

        public override void Resize(ShapeGeometry geometry)
        {
            this.Radius = (short)(geometry.OuterRadius >= 0 ? geometry.OuterRadius : 0);
        }

        public virtual void Draw(DrawingContext context)
        {
            byte[] color = ColorConverter.SplitToChannels((uint)this.Color);
            Color avaloniaColor = new(color[3], color[0], color[1], color[2]);

            IBrush brush = new SolidColorBrush(avaloniaColor);
            Point center = new(this.X, this.Y);
            context.DrawEllipse(brush, null, center, this.Radius, this.Radius);
        }
    }
}
