using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0628
{
    public class Solution0628 : Interface0628
    {
        /// <summary>
        /// 分类讨论
        /// 3个数字的乘积
        ///     结果为正数只有两种可能
        ///         1. 3个数字都是正数，为保证结果最大，取最大的3个正数
        ///         2. 3个数字有一个正数，两个负数，为保证结果最大，取最大的正数和最小的两个负数
        ///     结果为负数只有两种可能
        ///         1. 3个数字都是负数，为保证结果最大，取最大的3个负数
        ///         2. 3个数字有一个负数，两个正数，为保证结果最大，取最大的负数和最小的两个正数
        ///     结果为0只有一种可能
        ///         1. 3个数字中至少含有1个0
        /// 取以上5种可能（可能不足5种）中的最大值即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            List<int> positive = new List<int>(), negative = new List<int>();
            bool has_zero = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val > 0) positive.Add(val); else if (val < 0) negative.Add(val); else has_zero = true;
            }
            positive.Sort(); negative.Sort();

            int result = int.MinValue;
            int lenP = positive.Count, lenN = negative.Count;
            if (lenP >= 3) result = Math.Max(result, positive[lenP - 1] * positive[lenP - 2] * positive[lenP - 3]);
            if (lenP >= 1 && lenN >= 2) result = Math.Max(result, positive[lenP - 1] * negative[0] * negative[1]);
            if (result != int.MinValue) return result;
            if (has_zero) return 0;
            if (lenN >= 3) result = Math.Max(result, negative[lenN - 1] * negative[lenN - 2] * negative[lenN - 3]);
            if (lenN >= 1 && lenP >= 2) result = Math.Max(result, negative[lenN - 1] * positive[0] * positive[1]);

            return result;
        }

        /// <summary>
        /// 与MaximumProduct()逻辑一样，使用API再实现一次
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct2(int[] nums)
        {
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            int[] positive = nums.Where(i => i > 0).OrderBy(i => i).ToArray();
            int[] negative = nums.Where(i => i < 0).OrderBy(i => i).ToArray();
            bool has_zero = nums.Contains(0);

            int result = int.MinValue;
            int lenP = positive.Length, lenN = negative.Length;
            if (lenP >= 3) result = Math.Max(result, positive[^1] * positive[^2] * positive[^3]);
            if (lenP >= 1 && lenN >= 2) result = Math.Max(result, positive[^1] * negative[0] * negative[1]);
            if (result != int.MinValue) return result;
            if (has_zero) return 0;
            if (lenN >= 3) result = Math.Max(result, negative[^1] * negative[^2] * negative[^3]);
            if (lenN >= 1 && lenP >= 2) result = Math.Max(result, negative[^1] * positive[0] * positive[1]);

            return result;
        }
    }
}
