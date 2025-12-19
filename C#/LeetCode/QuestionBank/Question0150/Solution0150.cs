using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0150
{
    public class Solution0150 : Interface0150
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens) switch (token)
                {
                    case "+": stack.Push(stack.Pop() + stack.Pop()); break;
                    case "-": stack.Push(-stack.Pop() + stack.Pop()); break;
                    case "*": stack.Push(stack.Pop() * stack.Pop()); break;
                    case "/": stack.Push((int)(1M / stack.Pop() * stack.Pop())); break;
                    default: stack.Push(int.Parse(token)); break;
                }

            return stack.Pop();
        }
    }
}
