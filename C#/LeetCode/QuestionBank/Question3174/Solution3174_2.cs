using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3174
{
    public class Solution3174_2 : Interface3174
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ClearDigits(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (char.IsAsciiDigit(c)) stack.Pop(); else stack.Push(c);
            }

            return new string(stack.Reverse().ToArray());
        }
    }
}
