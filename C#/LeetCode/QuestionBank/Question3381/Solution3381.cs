using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3381
{
    public class Solution3381 : Interface3381
    {
        /// <summary>
        /// DP
        /// 令F(n,x)表示以nums[n]结尾，长度对k取余为x的非空子数组的最大和，那么F(n+1,x)可以被递推出来
        ///     F(n+1,x)可以独立使用nums[n+1]构成，也可以借助F(n,0)构成
        /// 假定数组长度为n，如果枚举全部长度为k, 2k, ...xk的子数组，即使借助前缀和+滑动窗口，依然会TLE
        ///     长为k的子数组有n-k个，长为2k的子数组有n-2k个，... ...
        ///     (n-k) + (n-2k) + ... + (n-n/k*k) = n^2/2k - n/2
        /// 
        /// 思路不对，先不写了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxSubarraySum(int[] nums, int k)
        {
            long result = 0;
            int len = nums.Length;
            if (k == 1)
            {
                result = nums[0];
                int sum = nums[0];
                for (int i = 1; i < len; i++) {
                    sum += nums[i];
                }
            }

            return result;
        }
    }
}
