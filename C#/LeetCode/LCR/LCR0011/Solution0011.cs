using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0011
{
    public class Solution0011 : Interface0011
    {
        /// <summary>
        /// 前缀和，枚举右维护左
        /// 将0看做-1，题目就是在查找和位0的子数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxLength(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, -1 } };
            for (int i = 0, sum = 0, last; i < len; i++)
            {
                sum += (nums[i] << 1) - 1;
                if (map.TryGetValue(sum, out last)) result = Math.Max(result, i - last); else map.Add(sum, i);
            }

            return result;
        }
    }
}
