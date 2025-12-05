using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3432
{
    public class Solution3432_api : Interface3432
    {
        public int CountPartitions(int[] nums)
        {
            return ((nums.Sum(x => x & 1) & 1) ^ 1) * (nums.Length - 1);
        }
    }
}
