using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3024
{
    public class Solution3024 : Interface3024
    {
        /// <summary>
        /// 三角不等式定理
        /// 三角形任意两边长度之和大于第三边
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string TriangleType(int[] nums)
        {
            if (nums[0] + nums[1] > nums[2] && nums[1] + nums[2] > nums[0] && nums[2] + nums[0] > nums[1])
            {
                if (nums[0] == nums[1] && nums[1] == nums[2] && nums[2] == nums[0]) return "equilateral";
                if (nums[0] == nums[1] || nums[1] == nums[2] || nums[2] == nums[0]) return "isosceles";
                return "scalene";
            }

            return "none";
        }
    }
}
