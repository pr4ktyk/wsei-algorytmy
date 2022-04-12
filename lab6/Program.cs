using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }

        class Stack<T>
        {
            private Node<T> _head;

            public void Push (T value)
            {
                Node<T> newNode = new Node<T> { Value = value, Next = _head };
                _head = newNode;
            }

            public bool IsEmpty()
            {
                return _head == null;
            }

            public T Pop()
            {
                if (IsEmpty())
                {
                    throw new Exception("Stack is empty!");
                }

                var result = _head.Value;
                _head = _head.Next;

                return result;
            }

            public void Reverse()
            {
                if (IsEmpty())
                {
                    throw new Exception("Stack is empty!");
                }

                var result = new Node<T>();
                while (!IsEmpty())
                {
                    result = new Node<T> { Value = _head.Value, Next = result };
                    _head = _head.Next;
                }

                _head = result;
            }
        }

        class Queue<T>
        {
            private Node<T> _head;
            private Node<T> _tail;
            private int _count = 0;

            public bool IsEmpty()
            {
                return _head == null;
            }

            public void Insert(T value)
            {
                Node<T> node = new Node<T> { Value = value };
                if (IsEmpty())
                {
                    _head = node;
                    _tail = _head;
                    _count++;
                    return;
                }
                _tail.Next = node;
                _tail = node;
                _count++;
            }

            public T Remove()
            {
                if (IsEmpty())
                {
                    throw new Exception("Queue is empty!");
                }

                T result = _head.Value;
                _head = _head.Next;
                _count--;
                return result;
            }

            public T[] ToArray()
            {
                T[] result = new T[_count];
                Node<T> node = _head;
                int i = 0;
                while (node != null)
                {
                    result[i++] = node.Value;
                    node = node.Next;
                }

                return result;
            }
        }

        static void Main(string[] args)
        {
            Node<string> node = new Node<string> { Value = "Adam" };
            node.Next = new Node<string> { Value = "Ewa" };
            node.Next.Next = new Node<string> { Value = "Karol" };

            var temp = node;
            while (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
            Console.WriteLine();
            Stack<string> stack = new Stack<string>();
            stack.Push("Adam");
            stack.Push("Andrzej");
            stack.Push("Wojtek");

            stack.Reverse();

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine();
            Queue<string> queue = new Queue<string>();
            queue.Insert("Piotr");
            queue.Insert("Paweł");
            queue.Insert("Jan");

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Remove());
            }

            foreach (var item in queue.ToArray())
            {
                Console.Write($"{item}, ");
            }

            int[] test = { 1, 2, 3 };
            Console.WriteLine();
        }
    }
}
