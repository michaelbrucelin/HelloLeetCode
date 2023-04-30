using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2099
{
    public class Solution2099_api : Interface2099
    {
        public int[] MaxSubsequence(int[] nums, int k)
        {
            return nums.Select((val, id) => (val, id))
                       .OrderByDescending(t => t.val)
                       .Take(k)
                       .OrderBy(t => t.id)
                       .Select(t => t.val)
                       .ToArray();
        }
    }
}
