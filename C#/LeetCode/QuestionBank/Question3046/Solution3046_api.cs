using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3046
{
    public class Solution3046_api : Interface3046
    {
        public bool IsPossibleToSplit(int[] nums)
        {
            if (nums.Length < 3) return true;
            return nums.GroupBy(x => x).All(g => g.Count() < 3);
        }
    }
}
