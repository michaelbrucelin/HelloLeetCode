using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1186
{
    public class Solution1186_2 : Interface1186
    {
        /// <summary>
        /// DP
        /// 令 F(N,0)表示arr[0..N]不取arr[N]的结果
        ///    F(N,1)表示arr[0..N]  取arr[n]的结果，且1个子数组（没有移除）的结果
        ///    F(N,2)表示arr[0..N]  取arr[n]的结果，且2个子数组（已经移除）的结果
        /// 那么F(N+1,x)？
        /// F(N+1,0) = Max(F(N,0), F(N,1), F(N,2))
        /// F(N+1,1) = Max(F(N,1), 0) + arr[N+1]
        /// F(N+1,2) = Max(F(N,2), F(N-1,1)) + arr[N+1]  这一步的推理是对的吗？从结果上看是正确的
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaximumSum(int[] arr)
        {
            int len = arr.Length;
            if (len == 1) return arr[0];
            if (len == 2) return Math.Max(arr[0] + arr[1], Math.Max(arr[0], arr[1]));

            int[,] dp = new int[len, 3];
            dp[1, 0] = arr[0]; dp[1, 1] = Math.Max(arr[0], 0) + arr[1]; dp[1, 2] = dp[1, 1];
            dp[2, 0] = Math.Max(dp[1, 0], dp[1, 1]); dp[2, 1] = Math.Max(dp[1, 1], 0) + arr[2]; dp[2, 2] = arr[0] + arr[2];
            for (int i = 3; i < len; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], Math.Max(dp[i - 1, 1], dp[i - 1, 2]));
                dp[i, 1] = Math.Max(dp[i - 1, 1], 0) + arr[i];
                dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 2, 1]) + arr[i];
            }

            return Math.Max(dp[len - 1, 0], Math.Max(dp[len - 1, 1], dp[len - 1, 2]));
        }
    }
}
