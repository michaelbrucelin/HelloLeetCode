using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3429
{
    public class Solution3429 : Interface3429
    {
        /// <summary>
        /// DP
        /// 0 -> [0,1] -> [1,0] | [1,2] | [2,0] -> 1 | 4 | 3
        /// 1 -> [1,0] -> [0,1] | [0,2] | [2,1] -> 0 | 2 | 5
        /// 2 -> [0,2] -> [1,0] | [2,0] | [2,1] -> 1 | 3 | 5
        /// 3 -> [2,0] -> [0,1] | [0,2] | [1,2] -> 0 | 2 | 4
        /// 4 -> [1,2] -> [0,1] | [2,0] | [2,1] -> 0 | 3 | 5
        /// 5 -> [2,1] -> [0,2] | [1,0] | [1,2] -> 2 | 1 | 4
        /// </summary>
        /// <param name="n"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public long MinCost(int n, int[][] cost)
        {
            int len = cost.Length >> 1;
            int[][] map = [[0, 1], [1, 0], [0, 2], [2, 0], [1, 2], [2, 1]];
            int[][] map2 = [[1, 4, 3], [0, 2, 5], [1, 3, 5], [0, 2, 4], [0, 3, 5], [2, 1, 4]];
            long[,] dp = new long[len, 6];
            for (int k = 0; k < 6; k++) dp[0, k] = cost[0][map[k][0]] + cost[^1][map[k][1]];
            for (int i = 1, j = cost.Length - 2; i < len; i++, j--) for (int k = 0; k < 6; k++)
                {
                    dp[i, k] = cost[i][map[k][0]] + cost[j][map[k][1]] + Math.Min(dp[i - 1, map2[k][0]], Math.Min(dp[i - 1, map2[k][1]], dp[i - 1, map2[k][2]]));
                }

            long result = long.MaxValue;
            for (int i = 0; i < 6; i++) result = Math.Min(result, dp[len - 1, i]);
            return result;
        }
    }
}
