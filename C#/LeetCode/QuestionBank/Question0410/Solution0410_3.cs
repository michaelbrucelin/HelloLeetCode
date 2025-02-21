using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0410
{
    public class Solution0410_3 : Interface0410
    {
        /// <summary>
        /// DP
        /// 本质上依然与Solution0410一样，不同之处在于
        ///     1. Solution0410是自底向上的，这里是自顶向下
        ///     2. 这里比Solution0410少了递归栈消耗的资源
        /// 提交通过了。。。，理论上这个和Solution0410的时间复杂度是一样的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SplitArray(int[] nums, int k)
        {
            if (k == 1) return nums.Sum();
            if (k == nums.Length) return nums.Max();

            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + nums[i];

            int[][] dp = new int[len][];
            for (int i = 0, min = 0, cnt = 0; i < len - 1; i++)   // 数组前i项的分组结果，只要没到最后一项，最多分k-1组就行
            {
                cnt = Math.Min(i + 1, k - 1) + 1;         // 数组前i项最多分Math.Min(i + 1, k - 1)组
                dp[i] = new int[cnt];
                dp[i][1] = sums[i + 1] - sums[0];         // 前i项只分1组的结果
                for (int c = 2; c < cnt; c++)             // 前i项分为c组的结果
                {
                    min = sums[len];
                    for (int j = i; j >= c - 1; j--)      // 枚举最后一组的起始位置
                    {
                        min = Math.Min(min, Math.Max(sums[i + 1] - sums[j], dp[j - 1][c - 1]));
                    }
                    dp[i][c] = min;
                }
            }

            // 枚举最后一组
            int result = sums[len];
            for (int i = len - 1; i >= k - 1; i--)
                result = Math.Min(result, Math.Max(sums[len] - sums[i], dp[i - 1][k - 1]));

            return result;
        }
    }
}
