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
        int X { get; }
        int Y { get; }
        ShapeColors Color { get; }

        void Move(ShapeGeometry geometry);
        void MoveDelta(ShapeGeometry geometry);
        void Resize(ShapeGeometry geometry);
        void Recolor(ShapeColors color);
    }
}
