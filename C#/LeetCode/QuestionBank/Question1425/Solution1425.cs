using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1425
{
    public class Solution1425 : Interface1425
    {
        /// <summary>
        /// DP
        /// F[N,0] 表示 nums[0..N] 不取 nums[N] 的最大子序列的和
        /// F[N,1] 表示 nums[0..N]   取 nums[N] 的最大子序列的和
        /// F[N+1,0] = MAX(F[N,0], F[N,1])
        /// F[N+1,1] = nums[i] + MAX(F[N+1-i,1]), 其中 1 <= i <= k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ConstrainedSubsetSum(int[] nums, int k)
        {
            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            if (max < 0) return max;

            int[,] dp = new int[len, 2];
            dp[0, 0] = 0;
            dp[0, 1] = nums[0];
            PriorityQueue<(int, int), int> maxpq = new PriorityQueue<(int, int), int>();
            maxpq.Enqueue((dp[0, 1], 0), -dp[0, 1]);
            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = nums[i];
                while (maxpq.Count > 0 && maxpq.Peek().Item2 < i - k) maxpq.Dequeue();
                if (maxpq.Count > 0 && maxpq.Peek().Item1 > 0) dp[i, 1] += maxpq.Peek().Item1;
                maxpq.Enqueue((dp[i, 1], i), -dp[i, 1]);
            }

            return Math.Max(dp[len - 1, 0], dp[len - 1, 1]);
        }
    }
}
