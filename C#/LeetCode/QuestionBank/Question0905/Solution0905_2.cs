using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0905
{
    public class Solution0905_2 : Interface0905
    {
        /// <summary>
        /// 原地更改
        /// 类似于快速排序的思路
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParity(int[] nums)
        {
            int ptr_l = -1, ptr_r = nums.Length, _t;
            while (++ptr_l < --ptr_r)
            {
                while (ptr_l < ptr_r && (nums[ptr_l] & 1) == 0) ptr_l++;
                while (ptr_r > ptr_l && (nums[ptr_r] & 1) == 1) ptr_r--;
                if (ptr_l < ptr_r)
                {
                    _t = nums[ptr_l]; nums[ptr_l] = nums[ptr_r]; nums[ptr_r] = _t;
                }
            }

            return nums;
        }
    }
}
