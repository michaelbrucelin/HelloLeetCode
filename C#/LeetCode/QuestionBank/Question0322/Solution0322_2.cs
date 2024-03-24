using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0322
{
    public class Solution0322_2 : Interface0322
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            HashSet<int> set = new HashSet<int>();
            foreach (int coin in coins)
            {
                if (coin == amount) return 1;
                if (coin < amount) set.Add(coin);
            }
            Dictionary<int, int> memory = new Dictionary<int, int>();
            dfs(set, amount, memory);

            return memory[amount];
        }

        private void dfs(HashSet<int> coins, int amount, Dictionary<int, int> memory)
        {
            if (memory.ContainsKey(amount)) return;

            int result = int.MaxValue;
            foreach (int coin in coins)
            {
                if (coin == amount)
                {
                    result = 1; break;
                }
                else if (coin < amount)
                {
                    dfs(coins, amount - coin, memory);
                    if (memory[amount - coin] != -1) result = Math.Min(result, memory[amount - coin] + 1);
                }
            }
            memory.Add(amount, result != int.MaxValue ? result : -1);
        }
    }
}
