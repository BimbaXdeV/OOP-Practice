using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public interface ICanvas
    {
        void Add(IShape shape, AdditionOptions options);
        void Add(IList<IShape> shapes, AdditionOptions options);
        void Remove(IShape shape);
        void Render(DrawingContext context);
    }
}
