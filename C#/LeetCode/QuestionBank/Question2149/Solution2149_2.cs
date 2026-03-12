using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2149
{
    public class Solution2149_2 : Interface2149
    {
        /// <summary>
        /// 原地交换
        /// 核心思路，从前向后遍历，当遇到一个“不对”的num时，向后逐项判断
        ///     如果后面的数字与“不对”的数字正负行相同，交换两个元素，因为需要保证所有正数与所有负数的相对顺序
        ///     如果后面的数字与“不对”的数字正负行不同，交换两个元素，回到上一级
        /// 在纸上画画就理清思路了
        /// 
        /// 逻辑没问题，但是时间复杂度时O(n^2)，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RearrangeArray(int[] nums)
        {
            int p0 = -1, p1, len = nums.Length;
            while (++p0 < len)
            {
                while (p0 < len && ((nums[p0] > 0 && (p0 & 1) == 0) || (nums[p0] < 0 && (p0 & 1) == 1))) p0++;
                if (p0 == len) break;
                p1 = p0;
                while (++p1 < len)
                {
                    (nums[p0], nums[p1]) = (nums[p1], nums[p0]);
                    if (Math.Sign(nums[p0]) != Math.Sign(nums[p1])) break;
                }
            }

            return nums;
        }
    }
}
