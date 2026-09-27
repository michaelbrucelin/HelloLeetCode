using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1190
{
    public class Solution1190 : Interface1190
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseParentheses(string s)
        {
            char[] buffer = [.. s];
            Stack<int> stack = new Stack<int>();
            int cnt = 0, len = s.Length;
            for (int i = 0; i < len; i++) switch (buffer[i])
                {
                    case '(': stack.Push(i); cnt += 2; break;
                    case ')':
                        for (int l = stack.Pop() + 1, r = i - 1; l < r; l++, r--) (buffer[l], buffer[r]) = (buffer[r], buffer[l]);
                        break;
                    default: break;
                }

            char[] result = new char[len - cnt];
            for (int i = 0, j = 0; i < len; i++) if (buffer[i] != '(' && buffer[i] != ')') result[j++] = buffer[i];
            return new string(result);
        }
    }
}
