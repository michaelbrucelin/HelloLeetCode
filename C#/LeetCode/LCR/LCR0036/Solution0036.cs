using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0036
{
    public class Solution0036 : Interface0036
    {
        /// <summary>
        /// 栈模拟
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            int x, y;
            foreach (string token in tokens) switch (token)
                {
                    case "+": y = stack.Pop(); x = stack.Pop(); stack.Push(x + y); break;
                    case "-": y = stack.Pop(); x = stack.Pop(); stack.Push(x - y); break;
                    case "*": y = stack.Pop(); x = stack.Pop(); stack.Push(x * y); break;
                    case "/": y = stack.Pop(); x = stack.Pop(); stack.Push(x / y); break;
                    default: stack.Push(Convert.ToInt32(token)); break;
                }

            return stack.Pop();
        }
    }
}
