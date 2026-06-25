using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2222
{
    public class Solution2222 : Interface2222
    {
        /// <summary>
        /// DP
        /// 第1轮dp，找出s[..i]中   0 的数量，  1 的数量
        /// 第2轮dp，找出s[..i]中  01 的数量， 10 的数量
        /// 第3轮dp，找出s[..i]中 010 的数量，101 的数量
        /// 也可以1轮，每个位置记录 0 1 01 10 010 101 6个状态即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long NumberOfWays(string s)
        {
            if (s.Length < 3) return 0;

            int len = s.Length;
            long[,] dp = new long[len, 6];
            switch ((s[0], s[1]))
            {
                case ('0', '0'): dp[0, 0] = 1; dp[1, 0] = 2; dp[0, 1] = 0; dp[1, 1] = 0; dp[1, 2] = 0; dp[1, 3] = 0; break;
                case ('0', '1'): dp[0, 0] = 1; dp[1, 0] = 1; dp[0, 1] = 0; dp[1, 1] = 1; dp[1, 2] = 1; dp[1, 3] = 0; break;
                case ('1', '0'): dp[0, 0] = 0; dp[1, 0] = 1; dp[0, 1] = 1; dp[1, 1] = 1; dp[1, 2] = 0; dp[1, 3] = 1; break;
                case ('1', '1'): dp[0, 0] = 0; dp[1, 0] = 0; dp[0, 1] = 1; dp[1, 1] = 2; dp[1, 2] = 0; dp[1, 3] = 0; break;
                default: break;
            }

            for (int i = 2, j; i < len; i++)
            {
                j = s[i] - '0';
                dp[i, 0] = dp[i - 1, 0] + 1 - j;                   //   0
                dp[i, 1] = dp[i - 1, 1] + j - 0;                   //   1
                dp[i, 2] = dp[i - 1, 2] + (j - 0) * dp[i - 1, 0];  //  01
                dp[i, 3] = dp[i - 1, 3] + (1 - j) * dp[i - 1, 1];  //  10
                dp[i, 4] = dp[i - 1, 4] + (1 - j) * dp[i - 1, 2];  // 010
                dp[i, 5] = dp[i - 1, 5] + (j - 0) * dp[i - 1, 3];  // 101
            }

            return dp[len - 1, 4] + dp[len - 1, 5];
        }
    }
}
