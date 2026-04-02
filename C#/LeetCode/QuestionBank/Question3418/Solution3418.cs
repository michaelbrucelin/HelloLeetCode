using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3418
{
    public class Solution3418 : Interface3418
    {
        /// <summary>
        /// DP
        /// 可以改为滚动数组，这里就不写了
        /// </summary>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int MaximumAmount(int[][] coins)
        {
            int rcnt = coins.Length, ccnt = coins[0].Length, coin;
            int[,,] dp = new int[rcnt, ccnt, 3];
            if (coins[0][0] >= 0) dp[0, 0, 0] = dp[0, 0, 1] = dp[0, 0, 2] = coins[0][0]; else dp[0, 0, 2] = coins[0][0];
            for (int c = 1; c < ccnt; c++)
            {
                coin = coins[0][c];
                dp[0, c, 0] = Math.Max(dp[0, c - 1, 0] + coin, dp[0, c - 1, 1]);
                dp[0, c, 1] = Math.Max(dp[0, c - 1, 1] + coin, dp[0, c - 1, 2]);
                dp[0, c, 2] = dp[0, c - 1, 2] + coin;
            }
            for (int r = 1; r < rcnt; r++)
            {
                coin = coins[r][0];
                dp[r, 0, 0] = Math.Max(dp[r - 1, 0, 0] + coin, dp[r - 1, 0, 1]);
                dp[r, 0, 1] = Math.Max(dp[r - 1, 0, 1] + coin, dp[r - 1, 0, 2]);
                dp[r, 0, 2] = dp[r - 1, 0, 2] + coin;
            }
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    coin = coins[r][c];
                    dp[r, c, 0] = Math.Max(Math.Max(dp[r, c - 1, 0], dp[r - 1, c, 0]) + coin, Math.Max(dp[r, c - 1, 1], dp[r - 1, c, 1]));
                    dp[r, c, 1] = Math.Max(Math.Max(dp[r, c - 1, 1], dp[r - 1, c, 1]) + coin, Math.Max(dp[r, c - 1, 2], dp[r - 1, c, 2]));
                    dp[r, c, 2] = Math.Max(dp[r, c - 1, 2], dp[r - 1, c, 2]) + coin;
                }

            rcnt--; ccnt--;
            return Math.Max(dp[rcnt, ccnt, 0], Math.Max(dp[rcnt, ccnt, 1], dp[rcnt, ccnt, 2]));
        }
    }
}
