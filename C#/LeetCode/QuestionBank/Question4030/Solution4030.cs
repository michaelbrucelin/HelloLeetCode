using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4030
{
    public class Solution4030 : Interface4030
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindromic(string s)
        {
            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                if (i != j)
                {
                    if (!IsPalindromic2(s[i], s[j])) return false;
                }
                else
                {
                    if (!IsPalindromic1(s[i])) return false;
                }
            }
            return true;

            static bool IsPalindromic1(char c)
            {
                int x = c, p = 7;
                bool[] bits = new bool[8];
                while (x > 0) { bits[p--] = (x & 1) == 1; x >>= 1; }
                for (int i = 0, j = 7; i < j; i++, j--) if (bits[i] != bits[j]) return false;
                return true;
            }

            static bool IsPalindromic2(char c1, char c2)
            {
                int x = c1, p = 7;
                bool[] bits1 = new bool[8];
                while (x > 0) { bits1[p--] = (x & 1) == 1; x >>= 1; }
                x = c2; p = 0;
                bool[] bits2 = new bool[8];
                while (x > 0) { bits2[p++] = (x & 1) == 1; x >>= 1; }
                for (int i = 0; i < 8; i++) if (bits1[i] != bits2[i]) return false;
                return true;
            }
        }
    }
}
