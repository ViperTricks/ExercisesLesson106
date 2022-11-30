///<summary>
///<author>Branium Academy</author>
///<seealso cref="Trang chủ" href="https://braniumacademy.net"/>
///<version>2022.06.10</version>
///</summary>

using System;

namespace ExercisesLesson106
{
    internal class Exercises4
    {
        static void Main()
        {
            var totalTestCase = int.Parse(Console.ReadLine());
            for (int i = 1; i <= totalTestCase; i++)
            {
                var data = Console.ReadLine();
                Console.WriteLine(ExecutePostfix(data));
            }
        }

		static double CalculateResult(double a, double b, char c)
		{
			double result = 0;
			if (c == '+')
			{
				result = a + b;
			}
			else if (c == '-')
			{
				result = a - b;
			}
			else if (c == '*')
			{
				result = a * b;
			}
			else if (c == '/')
			{
				result = a / b;
			}
			else if (c == '^')
			{
				result = Math.Pow(a, b);
			}
			return result;
		}

		static double ExecutePostfix(string str)
		{
			double result = 0;
			Stack<double> stack = new Stack<double>();
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == ' ')
				{
					continue;
				} // nếu kí tự tại vị trí i là toán tử
				else if (str[i] > '9' || str[i] < '0')
				{
					double b = stack.Top.Data;
					stack.Pop();
					double a = stack.Top.Data;
					stack.Pop();
					result = CalculateResult(a, b, str[i]);
					stack.Push(result);
				}
				else
				{ // trường hợp còn lại, kí tự tại vị trí i là toán hạng
					double number = 0;
					int c = str[i] - '0';
					while (c >= 0 && c <= 9 && i < str.Length)
					{
						number = number * 10 + c;
						i++;
                        if(i < str.Length)
                        {
                            c = str[i] - '0';
                        }
                    }
					i--;
					stack.Push(number);
				}
			}
			return stack.Top.Data;
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
