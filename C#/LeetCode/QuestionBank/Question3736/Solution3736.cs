using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3736
{
    public class Solution3736 : Interface3736
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMoves(int[] nums)
        {
            int max = nums[0], sum = nums[0], len = nums.Length;  // 题目限定数组非空
            for (int i = 1; i < len; i++) { max = Math.Max(max, nums[i]); sum += nums[i]; }

            return max * len - sum;
        }
    }
}
