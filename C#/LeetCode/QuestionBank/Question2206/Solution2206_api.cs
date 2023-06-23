using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2206
{
    public class Solution2206_api : Interface2206
    {
        public bool DivideArray(int[] nums)
        {
            return nums.GroupBy(i => i).All(g => (g.Count() & 1) == 0);
        }
    }
}
