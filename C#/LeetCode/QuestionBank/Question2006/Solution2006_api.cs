using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2006
{
    public class Solution2006_api : Interface2006
    {
        public int CountKDifference(int[] nums, int k)
        {
            return nums.SelectMany(num1 => nums.Select(num2 => (num1, num2)))
                       .Where(t => Math.Abs(t.num1 - t.num2) == k)
                       .Count() >> 1;
        }

        public int CountKDifference2(int[] nums, int k)
        {
            return nums.Select((num1, id1) => nums.Where((num2, id2) => id2 > id1 && Math.Abs(num2 - num1) == k)
                                                  .Count())
                       .Sum();
        }
    }
}
