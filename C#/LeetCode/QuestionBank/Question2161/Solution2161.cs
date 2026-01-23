using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2161
{
    public class Solution2161 : Interface2161
    {
        /// <summary>
        /// 遍历
        /// 这道题如果不要求原地操作，实在够不上中等难度
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        public int[] PivotArray(int[] nums, int pivot)
        {
            int len = nums.Length;
            int[] result = new int[len];
            int pl = 0, pr = len - 1;
            for (int i = 0; i < len; i++) if (nums[i] < pivot) result[pl++] = nums[i];
            for (int i = len - 1; i >= 0; i--) if (nums[i] > pivot) result[pr--] = nums[i];
            for (int i = pl; i <= pr; i++) result[i] = pivot;

            return result;
        }
    }
}
