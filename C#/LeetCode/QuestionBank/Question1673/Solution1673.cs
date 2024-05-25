using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1673
{
    public class Solution1673 : Interface1673
    {
        /// <summary>
        /// 贪心
        /// 1. 如果数组中最小的元素（有并列取第1个）后面有恰巧n=k-1个元素
        ///     后面的元素全部获取
        /// 2. 如果数组中最小的元素（有并列取第1个）后面有大于n>k-1个元素
        ///     取最小的元素
        ///     然后相同的逻辑从后面取k-1个元素
        /// 3. 如果数组中最小的元素（有并列取第1个）后面有不足n<k-1个元素
        ///     后面的元素全取
        ///     然后相同的逻辑从前面取k-n个元素
        /// 
        /// 先暴力写出来，然后再使用线段树/稀疏表来优化区间最小值的查询
        /// 逻辑没问题，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MostCompetitive(int[] nums, int k)
        {
            if (k == nums.Length) return nums;  // 题目限定k <= nums.Length

            int[] result = new int[k];
            MostCompetitive(nums, 0, nums.Length - 1, result, 0, k);

            return result;
        }

        private void MostCompetitive(int[] nums, int left, int right, int[] result, int start, int count)
        {
            if (count <= 0) return;

            int minid = left, _start, _count;
            for (int i = left + 1; i <= right; i++) if (nums[i] < nums[minid]) minid = i;
            switch ((_count = right - minid + 1) - count)
            {
                case 0:
                    for (int i = 0; i < count; i++) result[start + i] = nums[minid + i];
                    break;
                case > 0:
                    result[start] = nums[minid];
                    MostCompetitive(nums, minid + 1, right, result, start + 1, count - 1);
                    break;
                case < 0:
                    _start = start + count - _count;
                    for (int i = 0; i < _count; i++) result[_start + i] = nums[minid + i];
                    MostCompetitive(nums, left, minid - 1, result, start, count - _count);
                    break;
            }
        }
    }
}
