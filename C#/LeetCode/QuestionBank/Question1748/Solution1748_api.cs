using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1748
{
    public class Solution1748_api : Interface1748
    {
        public int SumOfUnique(int[] nums)
        {
            return nums.GroupBy(i => i).Where(g => g.Count() == 1).Sum(g => g.Key);
        }
    }
}
