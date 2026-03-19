using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3517
{
    public class Solution3517 : Interface3517
    {
        /// <summary>
        /// 计数 + 构造
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SmallestPalindrome(string s)
        {
            int len = s.Length;
            int[] cnts = new int[26];
            for (int i = 0; i < len; i++) cnts[s[i] - 'a']++;
            char[] chars = new char[len];
            if ((len & 1) != 0) { chars[len >> 1] = s[len >> 1]; cnts[s[len >> 1] - 'a']--; }
            for (int i = 0, j = len - 1, k = 0; i < j; i++, j--)
            {
                while (cnts[k] == 0) k++;
                chars[i] = chars[j] = (char)('a' + k);
                cnts[k] -= 2;
            }

            return new string(chars);
        }
    }
}
