using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3139
{
    public class Solution3139_err : Interface3139
    {
        /// <summary>
        /// 贪心
        /// 问题等价于cost2/=2，但是cost2与1一样，每次只能操作一个元素
        /// 如果cost1*2 <= cost2，全部使用cost1，否则尽可能多的使用cost2，并保证
        ///     1. cost2使用次数是偶数
        ///     2. 不能有某一个元素的操作次数超过总次数的一半
        /// 
        /// 逻辑错误，数组最终的值不一定是数组的最大值，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="cost1"></param>
        /// <param name="cost2"></param>
        /// <returns></returns>
        public int MinCostToEqualizeArray(int[] nums, int cost1, int cost2)
        {
            const int MOD = (int)1e9 + 7;
            long result = 0; int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            if ((cost1 << 1) <= cost2)
            {
                for (int i = 0; i < len; i++) result += max - nums[i];
                return (int)(result % MOD);
            }

            int[] diff = new int[len];
            long total = 0, maxdf = 0;
            for (int i = 0; i < len; i++) { diff[i] = max - nums[i]; total += diff[i]; maxdf = Math.Max(maxdf, diff[i]); }
            if ((maxdf << 1) <= total)
                return (int)(((total >> 1) * cost2 + cost1) % MOD);
            else
                return (int)(((total - maxdf) * cost2 + ((maxdf << 1) - total) * cost1) % MOD);
        }
    }
}
