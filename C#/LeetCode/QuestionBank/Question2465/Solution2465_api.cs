using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2465
{
    public class Solution2465_api : Interface2465
    {
        public int DistinctAverages(int[] nums)
        {
            Array.Sort(nums);
            return nums.Select((val, id) => val + nums[nums.Length - id - 1]).Distinct().Count();
        }
    }
}
