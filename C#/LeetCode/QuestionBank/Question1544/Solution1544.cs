using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1544
{
    public class Solution1544 : Interface1544
    {
        /// <summary>
        /// 栈 + 位运算
        /// 相同字母的大小写的异或值为32
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeGood(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (stack.Count == 0)
                {
                    stack.Push(c);
                }
                else
                {
                    if ((stack.Peek() ^ c) == 32) stack.Pop(); else stack.Push(c);
                }
            }

            return new string(stack.Reverse().ToArray());
        }
    }
}
