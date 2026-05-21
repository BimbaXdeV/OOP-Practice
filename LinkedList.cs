using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal class LinkedList<T> : IDisposable
    {
        private Node<T>? Head;
        private Node<T>? Tail;
        public int Size { get; private set; }

        public LinkedList()
        {
            // Навіщо я існую ):<
        }

        public LinkedList(T head)
        {
            Node<T> node = new(head);
            this.Head = node;
            this.Tail = node;
            this.Size = 1;
        }

        public void Add(T value)
        {
            Node<T> node = new(value);
            Add(node);
        }

        public void Add(IList<T> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                Node<T> node = new(values[i]);
                Add(node);
            }
        }

        public void Add(Node<T> node)
        {
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                this.Tail!.Next = node;
                this.Tail = node;
            }
            this.Size++;
        }

        public T? Pop(int index)
        {
            if (this.Head == null || this.Size == 0) return default;

            if (index == 0)
            {
                T reservedValue = this.Head.Value;

                this.Head = this.Head.Next;
                this.Size--;
                if (this.Head == null) this.Tail = null;
                return reservedValue;
            }

            Node<T>? current = this.Head;
            Node<T>? previous = null;

            for (int i = 0; i < index && current != null; i++)
            {
                previous = current;
                current = current.Next;
            }

            if (current != null)
            {
                if (current == this.Tail)
                {
                    this.Tail = previous;
                }

                T reservedValue = current.Value;
                previous!.Next = current.Next;
                this.Size--;

                return reservedValue;
            }
            return default;
        }

        public void Reverse()
        {
            if (this.Head == null || this.Size <= 1) return;
            
            Node<T>? previous = null;
            Node<T>? current = this.Head;
            Node<T>? next = null;

            this.Tail = this.Head;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            this.Head = previous;
        }

        //public void Remove(T value, bool multipleRemoving = false)
        //{
        //    if (this.Head == null || this.Size == 0) return;

        //    if (this.Head.Value != null && this.Head.Value.Equals(value))
        //    {
        //        this.Head = this.Head.Next;
        //        this.Size--;
        //        if (this.Head == null) this.Tail = null;
        //        return;
        //    }


        //    Node<T>? current = this.Head;
        //    Node<T>? previous = null;

        //    while (current != null && current.Value != null)
        //    {
        //        if (current.Value.Equals(value))
        //        {
        //            if (current == this.Tail)
        //            {
        //                this.Tail = previous;
        //            }

        //            previous!.Next = current.Next;
        //            this.Size--;

        //            if (!multipleRemoving) break;
        //        }
        //        previous = current;
        //        current = current.Next;
        //    }
        //}

        public override string ToString()
        {
            if (this.Head == null || this.Size == 0) return string.Empty;

            StringBuilder sb = new();
            Node<T>? current = this.Head;
            while (current != null)
            {
                sb.Append(current.Value + (current.Next != null ? ", " : string.Empty));
                current = current.Next;
            }

            return sb.ToString();
        }

        public void Dispose()
        {
            this.Head = null;
            this.Tail = null;
            this.Size = 0;
        }
    }
}
