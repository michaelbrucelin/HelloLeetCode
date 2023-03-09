using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0058_1
{
    public class Solution0058 : Interface0058
    {
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

        public string ReverseWords2(string s)
        {
            return string.Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
        }
    }
}
