using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0020
{
    public class Solution0020 : Interface0020
    {
        /// <summary>
        /// 中心向两边扩散
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountSubstrings(string s)
        {
            int result = 0, len = s.Length;

            // 长度为奇数的回文子串
            for (int i = 0, j; i < len; i++)
            {
                result++;
                j = 1;
                while (i - j >= 0 && i + j < len && s[i - j] == s[i + j])
                {
                    result++; j++;
                }
            }
            // 长度为偶数的回文子串
            for (int i = 1, j; i < len; i++) if (s[i] == s[i - 1])
                {
                    result++;
                    j = 1;
                    while (i - 1 - j >= 0 && i + j < len && s[i - 1 - j] == s[i + j])
                    {
                        result++; j++;
                    }
                }

            return result;
        }
    }
}
