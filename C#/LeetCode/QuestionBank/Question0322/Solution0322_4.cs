using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0322
{
    public class Solution0322_4 : Interface0322
    {
        /// <summary>
        /// DP
        /// 逻辑与Solution0322_2完全一样，只是将递归1:1翻译为DP
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            Array.Sort(coins);
            int len = coins.Length;
            int[] dp = new int[amount + 1];
            for (int _amount = 1; _amount <= amount; _amount++)
            {
                int result = int.MaxValue;
                for (int i = 0, coin; i < len; i++)
                {
                    coin = coins[i];
                    switch (coin - _amount)
                    {
                        case 0:
                            result = 1; goto EndLoop;
                        case > 0:
                            goto EndLoop;
                        default:
                            if (dp[_amount - coin] != -1) result = Math.Min(result, dp[_amount - coin] + 1);
                            break;
                    }
                }
                EndLoop:;
                dp[_amount] = result != int.MaxValue ? result : -1;
            }

            return dp[amount];
        }
    }
}
