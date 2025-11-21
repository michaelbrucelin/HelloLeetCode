using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1930
{
    public class Solution1930_2 : Interface1930
    {
        /// <summary>
        /// 遍历
        /// 逻辑同Solution1930，略加优化，先预处理出来每个字符第一次以及最后一次出现的位置
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountPalindromicSubsequence(string s)
        {
            int result = 0, mask = 0, len = s.Length;
            const int full = (1 << 26) - 1;
            int[,] pos = new int[26, 2];
            for (int i = 0; i < 26; i++) pos[i, 0] = pos[i, 1] = len;
            for (int i = 0, j; i < len; i++)                         // 找每个字符第1次出现的位置
            {
                j = s[i] - 'a';
                if (pos[j, 0] != len) continue;
                pos[j, 0] = i;
                if ((mask |= 1 << j) == full) break;
            }
            mask = 0;
            for (int i = 0; i < 26; i++) if (pos[i, 0] == len) { pos[i, 1] = -1; mask |= 1 << i; }
            if (mask != full) for (int i = len - 1, j; i >= 0; i--)  // 找每个字符最后1次出现的位置
                {
                    j = s[i] - 'a';
                    if (pos[j, 1] != len) continue;
                    pos[j, 1] = i;
                    if ((mask |= 1 << j) == full) break;
                }

            for (int i = 0; i < 26; i++)
            {
                if (pos[i, 1] <= pos[i, 0] + 1) continue;
                mask = 0;
                for (int j = pos[i, 0] + 1; j < pos[i, 1]; j++)
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
