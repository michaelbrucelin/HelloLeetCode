using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0518
{
    public class Solution0518_3 : Interface0518
    {
        /// <summary>
        /// DP
        /// 与上台阶一样，只不过上台阶是排列，这里是组合，所以仍然绕不过去的需要记录状态，所以内存依然会爆表
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            if (amount == 0) return 1;

            int len = coins.Length;
            Array.Sort(coins);
            HashSet<string> result = new HashSet<string>();
            List<int[]>[] dp = new List<int[]>[amount + 1];
            for (int i = 0; i <= amount; i++) dp[i] = new List<int[]>();
            dp[0].Add(new int[len]);
            for (int _amount = 1; _amount <= amount; _amount++)
            {
                for (int i = 0; i < len && _amount - coins[i] >= 0; i++) foreach (var arr in dp[_amount - coins[i]])
                    {
                        int[] _key = arr.ToArray();
                        _key[i]++;
                        dp[_amount].Add(_key);
                    }
            }
            foreach (var freq in dp[amount]) result.Add(string.Join(',', freq));

            return result.Count;
        }
    }
}
