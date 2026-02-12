using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3713
{
    public class Solution3713 : Interface3713
    {
        /// <summary>
        /// 前缀和 + 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestBalanced(string s)
        {
            if (s.Length < 3) return s.Length;

            int len = s.Length;
            int[,] cnts = new int[len + 1, 26];
            for (int i = 0, j; i < len; i++)
            {
                for (j = 0; j < 26; j++) cnts[i + 1, j] = cnts[i, j];
                j = s[i] - 'a';
                cnts[i + 1, j]++;
            }

            for (int span = len, cnt, _cnt; span > 2; span--) for (int i = 0, j = i + span - 1; j < len; i++, j++)
                {
                    cnt = 0;
                    for (int k = 0; k < 26; k++) if ((_cnt = cnts[j + 1, k] - cnts[i, k]) > 0)
                        {
                            if (cnt == 0) cnt = _cnt; else if (_cnt != cnt) goto CONTINUE;
                        }
                    return span;
                CONTINUE:;
                }
            return 2;
        }
    }
}
