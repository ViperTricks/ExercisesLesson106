///<summary>
///<author>Branium Academy</author>
///<seealso cref="Trang chủ" href="https://braniumacademy.net"/>
///<version>2022.06.10</version>
///</summary>

using System;

namespace ExercisesLesson106
{
    internal class Exercises2
    {
        static void Main()
        {
            var totalTestCase = int.Parse(Console.ReadLine());
            for (int i = 1; i <= totalTestCase; i++)
            {
                var data = Console.ReadLine().Split(' ');
                Stack<string> stack = new Stack<string>();
                for(int j = 0; j <= data.Length / 2; j++)
                {
                    stack.Push(data[j]);
                }
                var result = CheckStack(stack, data);
                var resultText = result ? "YES" : "NO";
                Console.WriteLine($"Test {i}: \n{resultText}");
            }
        }
        
        // phương thức kiểm tra tính đối xứng của mảng
        private static bool CheckStack(Stack<string> stack, string[] data)
        {
            int i = data.Length % 2 == 0? data.Length / 2 + 1 : data.Length / 2;
            // tiến hành so sánh các cặp phần tử từ giữa ra hai phía
            for (; i < data.Length; i++)
            {
                if(stack.Top.Data.CompareTo(data[i]) != 0)
                {
                    return false;
                }
                stack.Pop();
            }
            return true;
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
