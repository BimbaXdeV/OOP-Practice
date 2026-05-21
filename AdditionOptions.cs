using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    [Flags]
    public enum AdditionOptions : int
    {
        None = 0,
        UseDefaultColor = 1,
        CenterByX = 2,
        CenterByY = 4,
        AutoRedraw = 8,
        DebugInfo = 16
    }
}
