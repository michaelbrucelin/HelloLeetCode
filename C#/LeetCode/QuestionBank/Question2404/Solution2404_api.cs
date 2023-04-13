using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2404
{
    public class Solution2404_api : Interface2404
    {
        public int MostFrequentEven(int[] nums)
        {
            return nums.Where(i => (i & 1) != 1)
                       .DefaultIfEmpty(-1)
                       .GroupBy(i => i)
                       .OrderByDescending(g => g.Count()).ThenBy(g => g.Key)
                       .First().Key;
        }
    }
}
