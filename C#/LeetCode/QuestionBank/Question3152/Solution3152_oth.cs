using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3152
{
    public class Solution3152_oth : Interface3152
    {
        public bool[] IsArraySpecial(int[] nums, int[][] queries)
        {
            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 1; i < len; i++) sums[i + 1] = sums[i] + (((nums[i] ^ nums[i - 1]) & 1) ^ 1);

            len = queries.Length;
            bool[] result = new bool[len];
            for (int i = 0, from, to; i < len; i++)
            {
                (from, to) = (queries[i][0], queries[i][1]);
                result[i] = sums[to + 1] - sums[from + 1] == 0;
            }

            return result;
        }
    }
}
