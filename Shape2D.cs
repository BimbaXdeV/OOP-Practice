using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public abstract class Shape2D : Shape
    {
        public Shape2D() : base() { }
        public Shape2D(short x, short y, ShapeColors? c = null) : base(x, y, c) { }

        public override void Move(ShapeGeometry geometry)
        {
            this.X = geometry.X;
            this.Y = geometry.Y;
        }

        public override void MoveDelta(ShapeGeometry geometry)
        {
            this.X += geometry.X;
            this.Y += geometry.Y;
        }

        public override void Scale(float factor)
        {
            this.X = (short)(this.X * factor);
            this.Y = (short)(this.Y * factor);
        }
    }
}
