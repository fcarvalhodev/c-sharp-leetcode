using System;

namespace DoublyLinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
        public DoublyLinkedListNode<T> Tail
        {
            get;
            private set;
        }

        public DoublyLinkedListNode<T> Head
        {
            get;
            private set;
        }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> Next = null, DoublyLinkedListNode<T> Previous = null)
        {
            Value = value;
        }

    }
}
