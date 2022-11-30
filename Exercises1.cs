///<summary>
///<author>Branium Academy</author>
///<seealso cref="Trang chủ" href="https://braniumacademy.net"/>
///<version>2022.06.10</version>
///</summary>

using System;
using System.IO;

namespace ExercisesLesson106
{
    internal class Exercises1
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input2.txt");
            var totalTestCase = int.Parse(lines[0]);
            for (int i = 1; i <= totalTestCase; i++)
            {
                var data = lines[i].Split(' ');
                Stack<string> stack = new Stack<string>();
                foreach (var item in data)
                {
                    stack.Push(item);
                }
                ShowStack(stack);
            }
        }

        private static void ShowStack(Stack<string> stack)
        {
            while (!stack.IsEmpty())
            {
                Console.Write($"{stack.Top.Data} ");
                stack.Pop();
            }
            Console.WriteLine();
        }
    }

    class Stack<T>
    {
        public Node<T> Top { get; set; }

        public Stack()
        {
            Top = null;
        }

        // thêm node vào stack
        public void Push(T data)
        {
            var node = new Node<T>(data);
            node.Next = Top;
            Top = node;
        }

        // xóa node đầu stack
        public void Pop()
        {
            if (!IsEmpty())
            {
                var top = Top;
                Top = Top.Next;
                top.Next = null;
            }
            else
            {
                throw new Exception("Stack Is Empty.");
            }
        }

        // lấy phần tử đầu stack
        public T Peek()
        {
            if (!IsEmpty())
            {
                return Top.Data;
            }
            else
            {
                throw new Exception("Stack Is Empty.");
            }
        }

        // kiểm tra rỗng
        public bool IsEmpty()
        {
            return Top == null;
        }
    }

    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {
            Next = null;
        }

        public Node(T data) : this()
        {
            Data = data;
        }
    }
}
