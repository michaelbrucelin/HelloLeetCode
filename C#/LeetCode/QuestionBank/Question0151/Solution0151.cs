using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0151
{
    public class Solution0151 : Interface0151
    {
        /// <summary>
        /// 栈
        /// 用类似于C的方式模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            Stack<string> stack = new Stack<string>();

            int left = 0, right, len = s.Length;
            while (left < len)
            {
                while (left < len && s[left] == ' ') left++;
                if (left == len) break;
                right = left;
                while (right < len && s[right] != ' ') right++;
                stack.Push(s.Substring(left, right - left));
                left = right + 1;
            }

            StringBuilder result = new StringBuilder();
            while (stack.Count > 1)
            {
                result.Append(stack.Pop()); result.Append(' ');
            }
            if (stack.Count > 0) result.Append(stack.Pop());

            return result.ToString();
        }

        /// <summary>
        /// API
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords2(string s)
        {
            return string.Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
        }
    }
}
