using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0316
{
    public class Solution0316 : Interface0316
    {
        /// <summary>
        /// 单调栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicateLetters(string s)
        {
            int len = s.Length;
            int[] last = new int[26];
            Array.Fill(last, -1);
            for (int i = 0; i < len; i++) last[s[i] - 'a'] = i;
            bool[] has = new bool[26];

            Stack<char> stack = new Stack<char>();
            char c, _c;
            for (int i = 0; i < len; i++)
            {
                if (has[(c = s[i]) - 'a']) continue;
                while (stack.Count > 0 && c < (_c = stack.Peek()) && last[_c - 'a'] > i)
                {
                    stack.Pop(); has[_c - 'a'] = false;
                }
                stack.Push(c);
                has[c - 'a'] = true;
            }

            char[] result = new char[stack.Count];
            int idx = stack.Count;
            while (stack.Count > 0) result[--idx] = stack.Pop();
            return new string(result);
        }
    }
}
