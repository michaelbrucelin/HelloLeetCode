using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2164
{
    public class Solution2164 : Interface2164
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortEvenOdd(int[] nums)
        {
            int len = nums.Length;
            int[] even = new int[(len + 1) >> 1], odd = new int[len >> 1];
            for (int i = 0, j = 0; i < len; i += 2, j++) even[j] = nums[i];
            for (int i = 1, j = 0; i < len; i += 2, j++) odd[j] = nums[i];
            Array.Sort(even);
            Array.Sort(odd, (i, j) => j - i);
            for (int i = 0, j = 0; i < len; i += 2, j++) nums[i] = even[j];
            for (int i = 1, j = 0; i < len; i += 2, j++) nums[i] = odd[j];

            return nums;
        }
    }
}
