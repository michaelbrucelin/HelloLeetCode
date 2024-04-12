using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0019
{
    public class Solution0019 : Interface0019
    {
        /// <summary>
        /// 双指针遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome(string s)
        {
            if (s.Length < 2) return true;
            for (int i = 0, j = s.Length - 1; i < j; i++, j--) if (s[i] != s[j])
                {
                    if (ValidPalindrome(s, i + 1, j)) return true;
                    if (ValidPalindrome(s, i, j - 1)) return true;
                    return false;
                }

            return true;
        }

        private bool ValidPalindrome(string s, int pl, int pr)
        {
            if (pl >= pr) return true;
            for (; pl < pr; pl++, pr--) if (s[pl] != s[pr]) return false;

            return true;
        }
    }
}
