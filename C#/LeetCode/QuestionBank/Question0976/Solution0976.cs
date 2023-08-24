using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0976
{
    public class Solution0976 : Interface0976
    {
        /// <summary>
        /// 分析
        /// 1. 只要两条短边之和大于最长的边，三条边即可围成三角形
        /// 2. 先遍历一次，找出最长的三条边，可围成三角形，即为答案
        /// 3. 如果2没找到答案，数组排序，从大到小一次查找答案
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LargestPerimeter(int[] nums)
        {
            int first = 0, second = 0, third = 0, len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (num > first) { third = second; second = first; first = num; }
                else if (num > second) { third = second; second = num; }
                else if (num > third) { third = num; }
            }
            if (second + third > first) return first + second + third;

            Array.Sort(nums);
            for (int i = len - 3; i >= 0; i--)
                if (nums[i] + nums[i + 1] > nums[i + 2]) return nums[i] + nums[i + 1] + nums[i + 2];

            return 0;
        }
    }
}
