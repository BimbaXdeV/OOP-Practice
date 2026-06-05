using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public interface IShape
    {
        short X { get; }
        short Y { get; }
        ShapeColors Color { get; }

        void Move(ShapeGeometry geometry);
        void MoveDelta(ShapeGeometry geometry);
        void Resize(ShapeGeometry geometry);
        void Scale(float factor);
        void Recolor(ShapeColors color);
    }
}
