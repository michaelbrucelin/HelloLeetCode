using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2218
{
    public class Solution2218 : Interface2218
    {
        /// <summary>
        /// DFS
        /// 纯DFS，稍后考虑添加记忆化搜索，进而改为DP
        /// 
        /// 逻辑没问题，意料之中的TLE
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            return dfs(0, k);

            int dfs(int id, int k)
            {
                if (k == 0 || id >= piles.Count) return 0;

                int result = dfs(id + 1, k), _k = Math.Min(piles[id].Count, k);
                for (int i = 0, sum = 0; i < _k; i++)
                {
                    sum += piles[id][i];
                    result = Math.Max(result, sum + dfs(id + 1, k - i - 1));
                }

                return result;
            }
        }
    }
}
