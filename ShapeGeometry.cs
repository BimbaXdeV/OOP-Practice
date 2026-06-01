using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public ref struct ShapeGeometry
    {
        public short X;
        public short Y;
        public short Z;
        public short Width;
        public short Height;
        public short Depth;
        public short InnerRadius;
        public short OuterRadius;

        public ShapeGeometry(short x = 0, short y = 0, short z = 0, short w = 0, short h = 0, short d = 0, short or = 0, short ir = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Width = (short)(w >= 0 ? w : 0);
            this.Height = (short)(h >= 0 ? h : 0);
            this.Depth = (short)(d >= 0 ? d : 0);
            this.OuterRadius = (short)(or >= 0 ? or : 0);
            this.InnerRadius = (short)(ir >= 0 ? ir : 0);
        }
    }
}
