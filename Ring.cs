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
    public class Ring : Circle, IDrawable
    {
        [JsonProperty]
        public short InnerRadius { get; protected set; }
        public override double Area => Math.PI * (Math.Pow(this.Radius, 2) - Math.Pow(this.InnerRadius, 2));
        public override double Perimeter => (2 * Math.PI * this.Radius) + (2 * Math.PI * this.InnerRadius);

        public Ring(short x, short y, short outerR, short innerR, ShapeColors? c = null) : base(x, y, outerR, c)
        {
            this.InnerRadius = (short)(innerR >= 0 ? innerR : 0);
        }

        public override void Resize(ShapeGeometry geometry)
        {
            base.Resize(geometry);
            this.InnerRadius = (short)(geometry.InnerRadius >= 0 ? geometry.InnerRadius : 0);
        }

        public override void Scale(float factor)
        {
            base.Scale(factor);

            if (this.Radius < 2)
            {
                this.Radius = 2;
            }

            this.InnerRadius = (short)Math.Max(1, this.InnerRadius * factor);
            if (this.InnerRadius >= this.Radius)
            {
                this.InnerRadius = (short)(this.Radius - 1);
            }
        }

        public override void Draw(DrawingContext context)
        {
            byte[] color = ColorConverter.SplitToChannels((uint)this.Color);
            Color avaloniaColor = new(color[3], color[0], color[1], color[2]);

            IPen pen = new Pen(new SolidColorBrush(avaloniaColor), 2);
            Point center = new(this.X, this.Y);

            context.DrawEllipse(null, pen, center, this.Radius, this.Radius);
            context.DrawEllipse(null, pen, center, this.InnerRadius, this.InnerRadius);
        }
    }
}
