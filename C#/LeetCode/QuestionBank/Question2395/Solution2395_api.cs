using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2395
{
    public class Solution2395_api : Interface2395
    {
        public bool FindSubarrays(int[] nums)
        {
            int len = nums.Length;
            return Enumerable.Range(1, len - 1)
                             .Select(i => nums[i] + nums[i - 1])
                             .Distinct()
                             .Count() < len - 1;
        }

        public bool FindSubarrays2(int[] nums)
        {
            return nums.Skip(1)
                       .Select((i, id) => i + nums[id])
                       .Distinct()
                       .Count() < nums.Length - 1;
        }
    }
}
