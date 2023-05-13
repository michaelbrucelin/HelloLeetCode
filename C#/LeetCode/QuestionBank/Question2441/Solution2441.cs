using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2441
{
    public class Solution2441 : Interface2441
    {
        public int FindMaxK(int[] nums)
        {
            int result = -1;
            HashSet<int> set = new HashSet<int>(nums);
            foreach (int num in set)
                if (set.Contains(-num)) result = Math.Max(result, Math.Abs(num));

            return result;
        }
    }
}
