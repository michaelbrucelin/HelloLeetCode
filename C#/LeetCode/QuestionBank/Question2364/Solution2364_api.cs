using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2364
{
    public class Solution2364_api : Interface2364
    {
        public long CountBadPairs(int[] nums)
        {
            long result = nums.LongLength * (nums.Length - 1) >> 1;
            nums.Select((num,i)=>num-i)
                .GroupBy(x => x)
                .Select(g => g.LongCount())
                .ToList()
                .ForEach(x => result -= (x * (x - 1)) >> 1);

            return result;
        }
    }
}
