using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal static class ShapeAssembler
    {
        private static Type SharedType = typeof(IShape);

        public static Type[] GetAllTypes()
        {
            return Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .Where(t => t.IsAssignableFrom(SharedType) && !t.IsInterface && !t.IsAbstract)
                           .ToArray();
        }
    }
}
