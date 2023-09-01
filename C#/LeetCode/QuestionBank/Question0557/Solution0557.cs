using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0557
{
    public class Solution0557 : Interface0557
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right, len = s.Length;
            while (left < len)
            {
                while (left < len && chars[left] == ' ') left++;
                if (left == len) break;
                right = left + 1;
                while (right < len && chars[right] != ' ') right++;
                if (right - 1 > left) Reverse(chars, left, right - 1);
                left = right + 1;
            }

            return new string(chars);
        }

        private void Reverse(char[] chars, int left, int right)
        {
            while (left < right)
            {
                chars[left] = (char)(chars[left] ^ chars[right]);
                chars[right] = (char)(chars[left] ^ chars[right]);
                chars[left] = (char)(chars[left] ^ chars[right]);
                left++; right--;
            }
        }
    }
}
