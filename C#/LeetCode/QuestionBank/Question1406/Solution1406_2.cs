using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1406
{
    public class Solution1406_2 : Interface1406
    {
        /// <summary>
        /// 多维DP
        /// </summary>
        /// <param name="stoneValue"></param>
        /// <returns></returns>
        public string StoneGameIII(int[] stoneValue)
        {
            int len = stoneValue.Length;
            int[,,] dp = new int[len + 1, 2, 2];
            for (int i = len - 1; i >= 0; i--) for (int j = 0; j < 2; j++)
                {
                    dp[i, j, j] = dp[i + 1, 1 - j, j] + stoneValue[i];
                    dp[i, j, 1 - j] = dp[i + 1, 1 - j, 1 - j];
                    if (i + 1 < len && dp[i + 2, 1 - j, j] + stoneValue[i] + stoneValue[i + 1] > dp[i, j, j])
                    {
                        dp[i, j, j] = dp[i + 2, 1 - j, j] + stoneValue[i] + stoneValue[i + 1];
                        dp[i, j, 1 - j] = dp[i + 2, 1 - j, 1 - j];
                    }
                    if (i + 2 < len && dp[i + 3, 1 - j, j] + stoneValue[i] + stoneValue[i + 1] + stoneValue[i + 2] > dp[i, j, j])
                    {
                        dp[i, j, j] = dp[i + 3, 1 - j, j] + stoneValue[i] + stoneValue[i + 1] + stoneValue[i + 2];
                        dp[i, j, 1 - j] = dp[i + 3, 1 - j, 1 - j];
                    }
                }

            return (dp[0, 0, 0] - dp[0, 0, 1]) switch { > 0 => "Alice", < 0 => "Bob", _ => "Tie" };
        }
    }
}
