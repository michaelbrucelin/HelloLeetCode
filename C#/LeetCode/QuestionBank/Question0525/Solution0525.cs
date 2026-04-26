using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0525
{
    public class Solution0525 : Interface0525
    {
        /// <summary>
        /// 遍历
        /// 维护左，枚举右
        /// 对于nums[i]，计算nums[0..i]中1的数量-0的数量的差，假定为diff
        /// 那么对于j<i，如果nums[0..j]中1的数量-0的数量的差也是diff，那么nums[j+1,,i]就是一个解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxLength(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int result = 0, len = nums.Length;
            int[] cnts = [0, 0];
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, -1 } };
            for (int i = 0, diff; i < len; i++)
            {
                cnts[nums[i]]++;
                diff = cnts[1] - cnts[0];
                if (map.TryGetValue(diff, out int val)) result = Math.Max(result, i - val); else map.Add(diff, i);
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同FindMaxLength()，稍稍改动
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxLength2(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int result = 0, diff = 0, len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, -1 } };
            for (int i = 0; i < len; i++)
            {
                diff += (nums[i] << 1) - 1;
                if (map.TryGetValue(diff, out int val)) result = Math.Max(result, i - val); else map.Add(diff, i);
            }

            return result;
        }
    }
}
