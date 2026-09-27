using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1190
{
    public class Solution1190_off_2 : Interface1190
    {
        public string ReverseParentheses(string s)
        {
            int len = s.Length;
            int[] map = new int[len];
            Stack<int> stack = new Stack<int>();
            for (int i = 0, j; i < len; i++) switch (s[i])
                {
                    case '(': stack.Push(i); break;
                    case ')': j = stack.Pop(); map[i] = j; map[j] = i; break;
                }

            StringBuilder result = new StringBuilder();
            int idx = 0, step = 1;
            while (idx < len)
            {
                if (s[idx] == '(' || s[idx] == ')')
                {
                    idx = map[idx]; step = -step;
                }
                else
                {
                    result.Append(s[idx]);
                }
                idx += step;
            }

            return result.ToString();
        }
    }
}
