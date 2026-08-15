using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1541
{
    public class Solution1541 : Interface1541
    {
        /// <summary>
        /// 栈
        /// 没写完，先不写了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinInsertions(string s)
        {
            int result = 0, len = s.Length;
            Stack<char> stack = new Stack<char>();
            char c;
            for (int i = 0; i < len; i++)
            {
                if ((c = s[i]) == '(') { stack.Push(c); continue; }
                if (i + 1 == len) { }
            }
            result += stack.Count << 1;

            return result;
        }
    }
}
