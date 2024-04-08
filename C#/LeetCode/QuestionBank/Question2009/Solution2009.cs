using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2009
{
    public class Solution2009 : Interface2009
    {
        /// <summary>
        /// 排序 + 双指针
        /// 1. 最优解的最小值一定是数组中的“原值”（原有的值）
        ///     假定最优解的最小值是“替换”来的，那么也可以将其“替换”为最大值
        /// 2. 将数组排序
        /// 3. 双指针
        ///     p1从前向后遍历数组的每一项，p2从前向后，指向 <= nums[p1]+len-1 的最后一项
        ///     len - DistinctCount(nums[p1..p2]) 就是以 nums[p1] 为最小项的操作数
        ///     DistinctCount(nums[p1..p2]) 可以用一个哈希表来计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;

            Array.Sort(nums);
            int result = nums.Length, len = nums.Length, p1 = -1, p2 = 0;
            Dictionary<int, int> cnts = new Dictionary<int, int>() { { nums[0], 1 } };
            while (++p1 < len)
            {
                if (p1 > 0)
                {
                    if (--cnts[nums[p1 - 1]] == 0) cnts.Remove(nums[p1 - 1]);
                }
                while (p2 + 1 < len && nums[p2 + 1] <= nums[p1] + len - 1)
                {
                    if (cnts.ContainsKey(nums[++p2])) cnts[nums[p2]]++; else cnts.Add(nums[p2], 1);
                }
                result = Math.Min(result, len - cnts.Count);
            }

            return result;
        }
    }
}
