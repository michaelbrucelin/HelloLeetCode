using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1328
{
    public class Solution1328 : Interface1328
    {
        /// <summary>
        /// 贪心
        /// 注意，输入的字符串一定是回文串，这是个重要的信息
        /// </summary>
        /// <param name="palindrome"></param>
        /// <returns></returns>
        public string BreakPalindrome(string palindrome)
        {
            if (palindrome.Length == 1) return "";

            char[] chars = palindrome.ToCharArray();
            int n = chars.Length >> 1;
            for (int i = 0; i < n; i++) if (chars[i] != 'a')
                {
                    chars[i] = 'a'; return new string(chars);
                }

            chars[^1] = 'b';
            return new string(chars);
        }
    }
}