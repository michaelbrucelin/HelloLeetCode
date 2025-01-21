using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2218
{
    public class Solution2218_2 : Interface2218
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 逻辑同Solution2218，添加了记忆化搜索
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            return dfs(0, k);

            int dfs(int id, int k)
            {
                if (k == 0 || id >= piles.Count) return 0;
                if (memory.ContainsKey((id, k))) return memory[(id, k)];

                int result = dfs(id + 1, k), _k = Math.Min(piles[id].Count, k);
                for (int i = 0, sum = 0; i < _k; i++)
                {
                    sum += piles[id][i];
                    result = Math.Max(result, sum + dfs(id + 1, k - i - 1));
                }

                memory.Add((id, k), result);
                return result;
            }
        }

        /// <summary>
        /// 逻辑同MaxValueOfCoins()，将piles预处理为前缀和的形式
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValueOfCoins2(IList<IList<int>> piles, int k)
        {
            List<int[]> pcnts = new List<int[]>();
            foreach (List<int> pile in piles)
            {
                int _cnt = Math.Min(pile.Count, k);
                int[] _pile = new int[_cnt];
                _pile[0] = pile[0];
                for (int i = 1; i < _cnt; i++) _pile[i] = _pile[i - 1] + pile[i];
                pcnts.Add(_pile);
            }

            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            return dfs(0, k);

            int dfs(int id, int k)
            {
                if (k == 0 || id >= piles.Count) return 0;
                if (memory.ContainsKey((id, k))) return memory[(id, k)];

                int result = dfs(id + 1, k), _k = Math.Min(piles[id].Count, k);
                for (int i = 0; i < _k; i++)
                {
                    result = Math.Max(result, pcnts[id][i] + dfs(id + 1, k - i - 1));
                }

                memory.Add((id, k), result);
                return result;
            }
        }
    }
}
