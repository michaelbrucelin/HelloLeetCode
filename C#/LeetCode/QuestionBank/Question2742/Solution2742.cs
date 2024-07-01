using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2742
{
    public class Solution2742 : Interface2742
    {
        /// <summary>
        /// 未完成，心情不好，脑子很乱，不写了
        /// 
        /// 01背包
        /// 将time中每一项都加1，就是cost对应的收益，这就变成的01背包问题
        /// dp[i,j]表示前i个工人，完成至少j面墙的最小成本
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int PaintWalls(int[] cost, int[] time)
        {
            int n = cost.Length, max = int.MaxValue;
            for (int i = 0; i < n; i++) time[i]++;

            int[,] dp = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++) for (int j = 0; j <= n; j++) dp[i, j] = max;
            for (int i = 0, done; i < n; i++) for (int j = 1; j <= n; j++)
                {

                    // 只选择第i个工人
                    done = Math.Min(time[i], n);
                    dp[i + 1, done] = Math.Min(cost[i], dp[i + 1, done]);
                    // 第i个工人与前面所有工人的组合
                    //for (int j = 1; j <= n; j++) if (dp[i, j] != max)
                    //    {
                    //        done = Math.Min(j + time[i], n);
                    //        dp[i + 1, done] = Math.Min(dp[i, j] + cost[i], dp[i + 1, done]);
                    //    }
                }

            int result = int.MaxValue;
            for (int i = 1; i <= n; i++) if (dp[i, n] > 0) result = Math.Min(result, dp[i, n]);
            return result;
        }
    }
}
