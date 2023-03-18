using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0905
{
    public class Solution0905_api : Interface0905
    {
        public int[] SortArrayByParity(int[] nums)
        {
            Array.Sort(nums, (i1, i2) => (i1 & 1) - (i2 & 1));
            return nums;
        }

        public int[] SortArrayByParity2(int[] nums)
        {
            return nums.Select(i => (i, i & 1))
                       .OrderBy(t => t.Item2)
                       .Select(t => t.i)
                       .ToArray();
        }
    }
}
