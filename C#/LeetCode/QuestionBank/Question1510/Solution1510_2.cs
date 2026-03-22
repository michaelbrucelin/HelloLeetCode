using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1510
{
    public class Solution1510_2 : Interface1510
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution1510，改为DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool WinnerSquareGame(int n)
        {
            byte[] dp = new byte[n + 1];  // 1 true 2 false
            for (int i = 0, j; i <= n; i++) if (dp[i] == 0)
                {
                    // dp[i] = 2;
                    for (int k = 1; (j = i + k * k) <= n; k++) dp[j] = 1;
                    if (dp[n] == 1) return true;
                }

            return false;
        }

        public bool WinnerSquareGame2(int n)
        {
            bool[] dp = new bool[n + 1];
            for (int i = 0, j; i <= n; i++) if (!dp[i])
                {
                    for (int k = 1; (j = i + k * k) <= n; k++) dp[j] = true;
                    if (dp[n]) return true;
                }

            return false;
        }
    }
}
