using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2932
{
    public class Solution2932_api : Interface2932
    {
        public int MaximumStrongPairXor(int[] nums)
        {
            return nums.SelectMany(i => nums.Select(j => (i, j)))
                       .Where(t => Math.Abs(t.i - t.j) <= Math.Min(t.i, t.j))
                       .Select(t => t.i ^ t.j)
                       .Max();
        }
    }
}
