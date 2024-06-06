using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3168
{
    public class Solution3168 : Interface3168
    {
        /// <summary>
        /// 模拟，栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumChairs(string s)
        {
            int result = 0;
            Stack<bool> stack = new Stack<bool>();
            foreach (char c in s) switch (c)
                {
                    case 'E': stack.Push(true); result = Math.Max(result, stack.Count); break;
                    default: stack.Pop(); break;  // 题目保证此时栈非空
                }

            return result;
        }

        /// <summary>
        /// 逻辑同MinimumChairs()，将栈抽象为一个整型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumChairs2(string s)
        {
            int result = 0, stack = 0;
            foreach (char c in s) switch (c)
                {
                    case 'E': result = Math.Max(result, ++stack); break;
                    default: --stack; break;  // 题目保证此时栈非空
                }

            return result;
        }
    }
}
