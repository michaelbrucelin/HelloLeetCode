using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2873
{
    public class Solution2873_2 : Interface2873
    {
        /// <summary>
        /// 枚举j
        /// 1. 使两个整数的积更大，两个整数是更小的负数或是更大的正数
        /// 2. 预处理出nums[i..-1]的最大值与最小值，枚举j的同时，处理出来nums[0..(j-1)]的最大值与最小值
        /// 
        /// 题目保证没有负数，所以不用考虑两个极小的负数乘积的情况，这里考虑了，就不更改了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            long result = 0; int len = nums.Length;
            (int max, int min)[] suf = new (int max, int min)[len];
            int max = nums[^1], min = nums[^1];
            for (int i = len - 1; i >= 0; i--)
            {
                max = Math.Max(max, nums[i]); min = Math.Min(min, nums[i]); suf[i] = (max, min);
            }

            max = min = nums[0];
            for (int i = 1; i < len - 1; i++)
            {
                max = Math.Max(max, nums[i - 1]); min = Math.Min(min, nums[i - 1]);
                result = Math.Max(result, (min - (long)nums[i]) * suf[i + 1].min);
                result = Math.Max(result, (max - (long)nums[i]) * suf[i + 1].max);
            }

            return result;
        }
    }
}
