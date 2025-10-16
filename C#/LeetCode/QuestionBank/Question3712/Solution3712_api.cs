using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3712
{
    public class Solution3712_api : Interface3712
    {
        public int SumDivisibleByK(int[] nums, int k)
        {
            return nums.GroupBy(x => x).Where(x => x.Count() % k == 0).Sum(x => x.Key * x.Count());
        }
    }
}
