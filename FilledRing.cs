using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public class FilledRing : Ring
    {
        public FilledRing(short x, short y, short outerR, short innerR, ShapeColors? c = null) : base(x, y, outerR, innerR, c) { }

        public override void Draw(DrawingContext context)
        {
            byte[] color = ColorConverter.SplitToChannels((uint)this.Color);
            Color avaloniaColor = new(color[3], color[0], color[1], color[2]);

            double thickness = this.Radius - this.InnerRadius;
            double drawRadius = this.InnerRadius + (thickness / 2.0);

            IPen pen = new Pen(new SolidColorBrush(avaloniaColor), thickness);
            Point center = new(this.X, this.Y);

            context.DrawEllipse(null, pen, center, drawRadius, drawRadius);
        }
    }
}
