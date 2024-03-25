using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0518
{
    public class Solution0518_off : Interface0518
    {
        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach (int coin in coins) for (int i = coin; i <= amount; i++)
                {
                    dp[i] += dp[i - coin];
                }

            return dp[amount];
        }
    }
}
