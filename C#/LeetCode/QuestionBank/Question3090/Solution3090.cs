using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3090
{
    public class Solution3090 : Interface3090
    {
        /// <summary>
        /// 前缀和 + 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaximumLengthSubstring(string s)
        {
            int len = s.Length;
            int[,] pre = new int[len + 1, 26];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 26; j++) pre[i + 1, j] = pre[i, j];
                pre[i + 1, s[i] - 'a'] = pre[i, s[i] - 'a'] + 1;
            }

            for (int _len = len; _len > 2; _len--) for (int i = 0; i <= len - _len; i++)
                {
                    for (int j = 0; j < 26; j++) if (pre[i + _len, j] - pre[i, j] > 2) goto Continue;
                    return _len;
                    Continue:;
                }

            return 2;
        }
    }
}
