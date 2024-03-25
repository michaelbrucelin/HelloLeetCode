using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0518
{
    public class Solution0518_2 : Interface0518
    {
        /// <summary>
        /// DFS + 回溯
        /// 逻辑同Solution0518
        /// 原则上时间复杂度与Solution0518一样，仍然会TLE，但是空间复杂度会好很多，写一下玩玩
        /// 
        /// 逻辑没问题，但是空间复杂度仍然很大
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            if (amount == 0) return 1;

            HashSet<string> result = new HashSet<string>();
            Array.Sort(coins);
            dfs(amount, 0, coins, new int[coins.Length], result, new HashSet<string>());

            return result.Count;
        }

        private void dfs(int amount, int curr, int[] coins, int[] freq, HashSet<string> result, HashSet<string> visited)
        {
            int _amount; string _visit;
            for (int i = 0; i < coins.Length; i++)
            {
                _amount = curr + coins[i];
                freq[i]++;
                _visit = string.Join(',', freq);
                if (_amount < amount)
                {
                    if (!visited.Contains(_visit))
                    {
                        visited.Add(_visit);
                        dfs(amount, _amount, coins, freq, result, visited);
                    }
                    freq[i]--;
                }
                else
                {
                    if (_amount == amount) result.Add(_visit);
                    freq[i]--;
                    break;
                }
            }
        }
    }
}
