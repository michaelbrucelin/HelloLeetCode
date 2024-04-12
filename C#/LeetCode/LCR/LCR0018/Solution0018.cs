using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0018
{
    public class Solution0018 : Interface0018
    {
        /// <summary>
        /// 双指针遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            if (s.Length < 2) return true;

            int pl = -1, pr = s.Length;
            while (++pl < --pr)
            {
                while (pl < pr && !char.IsAsciiLetterOrDigit(s[pl])) pl++;
                while (pr > pl && !char.IsAsciiLetterOrDigit(s[pr])) pr--;
                if (char.IsAsciiDigit(s[pl]) || char.IsAsciiDigit(s[pr]))
                {
                    if (s[pl] != s[pr]) return false;
                }
                else if (char.IsAsciiLetter(s[pl]) || char.IsAsciiLetter(s[pr]))
                {
                    if ((s[pl] | 32) != (s[pr] | 32)) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 逻辑与IsPalindrome()一样，代码略加优化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome2(string s)
        {
            if (s.Length < 2) return true;

            int pl = -1, pr = s.Length;
            while (++pl < --pr)
            {
                while (pl < pr && !char.IsAsciiLetterOrDigit(s[pl])) pl++;
                while (pr > pl && !char.IsAsciiLetterOrDigit(s[pr])) pr--;
                if ((s[pl] != s[pr]) && ((s[pl] | 32) != (s[pr] | 32))) return false;
            }

            return true;
        }
    }
}
