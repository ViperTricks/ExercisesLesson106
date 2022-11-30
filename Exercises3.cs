///<summary>
///<author>Branium Academy</author>
///<seealso cref="Trang chủ" href="https://braniumacademy.net"/>
///<version>2022.06.10</version>
///</summary>

using System;

namespace ExercisesLesson106
{
    internal class Exercises3
    {
        static void Main()
        {
            var totalTestCase = int.Parse(Console.ReadLine());
            for (int i = 1; i <= totalTestCase; i++)
            {
                var data = Console.ReadLine();
                InfixToPostfix(data);
                Console.WriteLine();
            }
        }

        static int PriorityLevel(char c)
        {
            if (c == '+' || c == '-')
            {
                return 1;
            }
            else if (c == '/' || c == '*')
            {
                return 2;
            }
            else if (c == '^')
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        // phương thức chuyển đổi trung tố sang hậu tố
        static void InfixToPostfix(string input)
        {
            Stack<char> stack = new Stack<char>();
            int size = input.Length;
            for (int i = 0; i < size; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }
                else
                {
                    if (input[i] == '+' || input[i] == '-' ||
                        input[i] == '*' || input[i] == '/' || input[i] == '^')
                    {
                        while (!stack.IsEmpty() &&
                            PriorityLevel(input[i]) <= PriorityLevel(stack.Top.Data))
                        {
                            Console.Write($"{stack.Top.Data} ");
                            stack.Pop();
                        }
                        stack.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        char op = stack.Top.Data;
                        stack.Pop();
                        while (!(op == '('))
                        {
                            Console.Write($"{op} ");
                            op = stack.Top.Data;
                            stack.Pop();
                        }
                    }
                    else if (input[i] == '(')
                    {
                        stack.Push(input[i]);
                    }
                    else
                    {
                        int number = 0;
                        int c = input[i] - 48;
                        while (c >= 0 && c <= 9 && i < input.Length)
                        {
                            number = number * 10 + c;
                            i++;
                            if(i < input.Length)
                            {
                                c = input[i] - 48;
                            }
                        }
                        i--;
                        Console.Write($"{number} ");
                    }
                }
            }
            // pop cac phan tu con lai cua stack
            while (!stack.IsEmpty())
            {
                char op = stack.Top.Data;
                stack.Pop();
                if (op != '(')
                {
                    Console.Write($"{op} ");
                }
            }
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
