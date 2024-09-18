using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2390
{
    public class Solution2390 : Interface2390
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveStars(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '*')
                {
                    if (stack.Count > 0) stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            int len = stack.Count;
            char[] result = new char[len];
            for (int i = len - 1; i >= 0; i--) result[i] = stack.Pop();

            return new string(result);
        }
    }
}
