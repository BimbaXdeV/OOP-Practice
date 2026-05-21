using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal record Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        // Value only
        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        // Value and node
        public Node(T value, Node<T>? next)
        {
            this.Value = value;
            this.Next = next;
        }

        // Value and &node
        public Node(T value, ref Node<T>? next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
