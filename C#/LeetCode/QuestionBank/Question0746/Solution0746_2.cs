using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0746
{
    public class Solution0746_2 : Interface0746
    {
        /// <summary>
        /// 递归
        /// 提交会超时，写着玩
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            return rec(cost.Length, cost);
        }

        private int rec(int n, int[] cost)
        {
            if (n <= 1) return 0;
            return Math.Min(rec(n - 1, cost) + cost[n - 1], rec(n - 2, cost) + cost[n - 2]);
        }

        /// <summary>
        /// 记忆化搜索
        /// 由于递归中有大量的重复计算，使用记忆化搜索来加速递归
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs2(int[] cost)
        {
            int[] buffer = new int[cost.Length];
            return rec2(cost.Length, cost, buffer);
        }

        private int rec2(int n, int[] cost, int[] buffer)
        {
            if (n <= 1) return 0;

            if (buffer[n - 1] == 0) buffer[n - 1] = rec2(n - 1, cost, buffer);
            if (buffer[n - 2] == 0) buffer[n - 2] = rec2(n - 2, cost, buffer);
            return Math.Min(buffer[n - 1] + cost[n - 1], buffer[n - 2] + cost[n - 2]);
        }
    }
}
