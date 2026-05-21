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
        public int InnerRadius { get; protected set; }
        public override double Area => Math.PI * (Math.Pow(this.Radius, 2) - Math.Pow(this.InnerRadius, 2));
        public override double Perimeter => (2 * Math.PI * this.Radius) + (2 * Math.PI * this.InnerRadius);

        public Ring(int x, int y, int outerR, int innerR, ShapeColors? c = null) : base(x, y, outerR, c)
        {
            this.InnerRadius = innerR >= 0 ? innerR : 0;
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
