using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0283
{
    public class Solution0283_2 : Interface0283
    {
        /// <summary>
        /// 原地构造结果
        /// 从前向后将非0的值移动到数组前面，然后后面直接填充0，时间复杂度为O(n)
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++) if (nums[i] != 0) nums[j++] = nums[i];
            for (int i = j; i < nums.Length; i++) nums[i] = 0;

            return;
        }
    }
}
