using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1930
{
    public class Solution1930 : Interface1930
    {
        /// <summary>
        /// 遍历
        /// 假定回文子串的首尾是a，找出第1个a域最后1个a，两者之间不同字符的数量就是首尾为a的不同子回文序列的数量
        /// 遍历26轮即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountPalindromicSubsequence(string s)
        {
            int result = 0, p1, p2, mask, len = s.Length;
            const int full = (1 << 26) - 1;
            char c;
            for (int i = 0; i < 26; i++)
            {
                c = (char)('a' + i);
                for (p1 = 0; p1 < len; p1++) if (s[p1] == c) break;
                if (p1 == len) continue;
                for (p2 = len - 1; p2 > p1; p2--) if (s[p2] == c) break;
                if (p2 <= p1 + 1) continue;
                mask = 0;
                for (int j = p1 + 1; j < p2; j++)
                {
                    if ((mask |= 1 << (s[j] - 'a')) == full) goto FULL;
                }
                result += Count1(mask);
                continue;
            FULL:;
                result += 26;
            }

            return result;

            static int Count1(int x)
            {
                int count1 = 0;
                while (x > 0) { x &= x - 1; count1++; }
                return count1;
            }
        }
    }
}
