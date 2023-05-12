using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1330
{
    public class Solution1330 : Interface1330
    {
        /// <summary>
        /// 暴力枚举
        /// 1. 只能翻转一次，也就是只改变两组相邻的值（测试知也可以一次不翻转）
        /// 2. 可以暴力模拟任意的两组位置
        ///     如果翻转了nums[i..j]，那么会影响到到(nums[i-1], nums[i])与(nums[j], nums[j+1])这两组值
        ///                                         (nums[i-1], nums[j])  (nums[i], nums[j+1])
        /// 逻辑没问题，可预见的提交会超时，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxValueAfterReverse(int[] nums)
        {
            int len = nums.Length;
            int[] diffs = new int[len - 1];
            for (int i = 0; i < len - 1; i++) diffs[i] = Math.Abs(nums[i + 1] - nums[i]);

            int sum = diffs.Sum(), diff = 0;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    if (i == 0 && j == len - 1) continue;
                    if (i == 0)
                    {
                        diff = Math.Max(diff, Math.Abs(nums[j + 1] - nums[i]) - diffs[j]);
                    }
                    else if (j == len - 1)
                    {
                        diff = Math.Max(diff, Math.Abs(nums[j] - nums[i - 1]) - diffs[i - 1]);
                    }
                    else  // i == 0 && j == len - 1
                    {
                        diff = Math.Max(diff, Math.Abs(nums[j + 1] - nums[i]) - diffs[j] +
                                              Math.Abs(nums[j] - nums[i - 1]) - diffs[i - 1]);
                    }
                }

            return sum + diff;
        }
    }
}
