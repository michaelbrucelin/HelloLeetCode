using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1191
{
    public class Solution1191 : Interface1191
    {
        /// <summary>
        /// 分析
        /// 首先，找出数组中所有子数组中的最大的和，DP可解
        /// 如果数组长度小于3，那么直接求即可，否则
        /// 假定sum = sum(arr)
        /// 如果sum <= 0，那么只考虑两个arr连接就够用了，多了没用
        /// 如果sum > 0，结果为 sum * (k - 2)，再算两头的即可
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KConcatenationMaxSum(int[] arr, int k)
        {
            if (k == 1) return MaxSubSum(arr);
            int[] _arr = [.. arr, .. arr];
            int result2 = MaxSubSum(_arr);
            if (k == 2) return result2;

            int len = arr.Length;
            long sum = 0;
            for (int i = 0; i < len; i++) sum += arr[i];
            if (sum <= 0) return result2;

            const int MOD = (int)1e9 + 7;
            return (int)((result2 + sum * (k - 2)) % MOD);

            static int MaxSubSum(int[] nums)
            {
                int len = nums.Length;
                int[] dp = new int[len];
                dp[0] = nums[0];
                for (int i = 1; i < len; i++) dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);

                int result = 0;
                for (int i = 0; i < len; i++) result = Math.Max(result, dp[i]);
                return result % MOD;
            }
        }
    }
}
