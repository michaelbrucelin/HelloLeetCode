using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0462
{
    public class Solution0462 : Interface0462
    {
        /// <summary>
        /// 数学
        /// 中位数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMoves2(int[] nums)
        {
            Array.Sort(nums);

            int result = 0, id = nums.Length >> 1, len = nums.Length, pivot = nums[id];
            for (int i = 0; i < id; i++) result += pivot - nums[i];
            for (int i = id + 1; i < len; i++) result += nums[i] - pivot;

            return result;
        }
    }
}
