using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public ref struct ShapeGeometry
    {
        public int X;
        public int Y;
        public int Z;
        public int Width;
        public int Height;
        public int Depth;

        public ShapeGeometry(int x = 0, int y = 0, int z = 0, int w = 0, int h = 0, int d = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Width = w >= 0 ? w : 0;
            this.Height = h >= 0 ? h : 0;
            this.Depth = d >= 0 ? d : 0;
        }
    }
}
