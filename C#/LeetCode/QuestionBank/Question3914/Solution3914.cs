using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3914
{
    public class Solution3914 : Interface3914
    {
        /// <summary>
        /// 贪心
        /// 从前向后遍历即可，每次的子数组都是当前位置到最后一个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MinOperations(int[] nums)
        {
            long result = 0; int len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] < nums[i - 1]) result += nums[i - 1] - nums[i];
            }

            return result;
        }
    }
}
