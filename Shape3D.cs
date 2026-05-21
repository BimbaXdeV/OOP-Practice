using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public abstract class Shape3D : Shape
    {
        public int Z { get; protected set; }

        public Shape3D()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        public Shape3D(int x, int y, int z, ShapeColors? c = null)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Color = (ShapeColors)(c != null ? c : _defaultColor);
        }

        public override void Move(ShapeGeometry geometry)
        {
            this.X = geometry.X;
            this.Y = geometry.Y;
            this.Z = geometry.Z;
        }

        public override void MoveDelta(ShapeGeometry geometry)
        {
            this.X += geometry.X;
            this.Y += geometry.Y;
            this.Z += geometry.Z;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} | X: {this.X}, Y: {this.Y}, Z: {this.Z} | color: {string.Join(", ", ColorConverter.SplitToChannels((uint)this.Color))}";
        }
    }
}
