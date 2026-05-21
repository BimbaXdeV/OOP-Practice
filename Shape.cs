using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public abstract class Shape : IShape
    {
        public static readonly ShapeColors _defaultColor = ShapeColors.Black;

        public int X { get; protected set; }
        public int Y { get; protected set; }
        [JsonProperty]
        public ShapeColors Color { get; protected set; }

        public Shape()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Shape(int x, int y, ShapeColors? c = null)
        {
            this.X = x;
            this.Y = y;
            this.Color = (ShapeColors)(c != null ? c : _defaultColor);
        }

        public abstract void Move(ShapeGeometry geometry);
        public abstract void MoveDelta(ShapeGeometry geometry);
        public abstract void Resize(ShapeGeometry geometry);
        public void Recolor(ShapeColors color)
        { 
            this.Color = color;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} | X: {this.X}, Y: {this.Y} | color (RGBA): {string.Join(", ", ColorConverter.SplitToChannels((uint)this.Color))}";
        }
    }
}
