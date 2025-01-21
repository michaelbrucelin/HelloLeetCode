using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2218
{
    public class Solution2218_3 : Interface2218
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution2218_2，改为DP
        ///     dp[i,j]表示piles前i项执行j次的最大值
        ///     缺点：可能会枚举不会出现的可能，时间复杂度增高
        ///     优点：不需要递归，不会要哈希化，时间复杂度降低
        /// TLE，慢了很多，参考测试用例04，怀疑是有没必要的检测状态导致的
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValueOfCoins2(IList<IList<int>> piles, int k)
        {
            List<int[]> pcnts = new List<int[]>();
            foreach (List<int> pile in piles)
            {
                int _cnt = Math.Min(pile.Count, k) + 1;
                int[] _pile = new int[_cnt];
                for (int i = 1; i < _cnt; i++) _pile[i] = _pile[i - 1] + pile[i - 1];
                pcnts.Add(_pile);
            }

            int pcnt = piles.Count;
            int[,] dp = new int[pcnt + 1, k + 1];
            for (int i = 1; i <= pcnt; i++)
            {
                for (int j = 1; j <= k; j++) for (int x = 0, y = j; y >= 0; x++, y--)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, x] + (y < pcnts[i - 1].Length ? pcnts[i - 1][y] : 0));
                    }
            }

            return dp[pcnt, k];
        }

        /// <summary>
        /// 逻辑同MaxValueOfCoins()，剪枝掉了一些不可能的状态检测
        /// 
        /// 快了一些，但是依然TLE
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            List<int[]> pcnts = new List<int[]>();
            foreach (List<int> pile in piles)
            {
                int _cnt = Math.Min(pile.Count, k) + 1;
                int[] _pile = new int[_cnt];
                for (int i = 1; i < _cnt; i++) _pile[i] = _pile[i - 1] + pile[i - 1];
                pcnts.Add(_pile);
            }

            int pcnt = piles.Count;
            int[,] dp = new int[pcnt + 1, k + 1];
            for (int i = 1, cnt, total_cnt = 0; i <= pcnt; i++)
            {
                total_cnt += piles[i - 1].Count;
                cnt = Math.Min(total_cnt, k);
                for (int j = 1; j <= cnt; j++) for (int x = 0, y = j; y >= 0; x++, y--)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, x] + (y < pcnts[i - 1].Length ? pcnts[i - 1][y] : 0));
                    }
            }

            return dp[pcnt, k];
        }
    }
}
