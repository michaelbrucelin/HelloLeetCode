using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0303
{
    public class Solution0303
    {
    }

    /// <summary>
    /// 前缀和
    /// </summary>
    public class NumArray : Interface0303
    {
        public NumArray(int[] nums)
        {
            sums = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++) sums[i + 1] = sums[i] + nums[i];
        }

        private int[] sums;

        public int SumRange(int left, int right)
        {
            return sums[right + 1] - sums[left];
        }
    }
}
