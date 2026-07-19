using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1937
{
    public class Solution1937_2 : Interface1937
    {
        /// <summary>
        /// DP + 大顶堆
        /// 核心思路同Solution1937，Solution1937 TLE主要出现在计算dp[r,c]时，遍历了上面整行，即dp[r-c,...]
        /// 这里做出下面优化
        /// 假定dp[r,c]已经计算出结果，就该计算dp[r,c+1]了，对于dp[r-1,0..c+1]，最大值还是最大值，但是得分需要-1，而dp[r-1,c+1..]最大值也还是最大值，但是得分需要+1
        /// 所以对于每一行，用一个值维护来自左侧的最大值，用大顶堆维护来自右侧的最大值，这样就将时间复杂度降低一个数量级
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public long MaxPoints(int[][] points)
        {
            int rcnt = points.Length, ccnt = points[0].Length;
            long[] dp = new long[ccnt], _dp = new long[ccnt];
            for (int c = 0; c < ccnt; c++) dp[c] = points[0][c];
            long lmax;
            PriorityQueue<(long, int), long> maxpq = new PriorityQueue<(long, int), long>();
            for (int r = 1; r < rcnt; r++)
            {
                lmax = dp[0];
                maxpq.Clear();
                for (int c = 0; c < ccnt; c++) maxpq.Enqueue((dp[c] - c, c), c - dp[c]);
                for (int c = 0; c < ccnt; c++)
                {
                    while (maxpq.Count > 0 && maxpq.Peek().Item2 < c) maxpq.Dequeue();
                    _dp[c] = points[r][c] + (maxpq.Count > 0 ? Math.Max(lmax, maxpq.Peek().Item1 + c) : lmax);
                    lmax = Math.Max(lmax - 1, dp[c] - 1);
                }
                Array.Copy(_dp, dp, ccnt);
            }

            long result = 0;
            for (int c = 0; c < ccnt; c++) result = Math.Max(result, dp[c]);
            return result;
        }
    }
}
