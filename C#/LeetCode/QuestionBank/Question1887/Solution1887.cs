using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1887
{
    public class Solution1887 : Interface1887
    {
        /// <summary>
        /// 模拟
        /// 使用大顶堆来模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ReductionOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;
            Array.Sort(nums);

            // int result = 0, right = nums.Length, p1 = nums.Length - 1, p2 = nums.Length - 1;
            int result = 0, right = nums.Length - 1, p1 = right, p2 = p1;
            while (true)
            {
                while (--p2 >= 0 && nums[p2] == nums[p1]) ;
                if (p2 == -1) break;
                result += right - p2;
                p1 = p2;
            }

            return result;
        }
    }
}
