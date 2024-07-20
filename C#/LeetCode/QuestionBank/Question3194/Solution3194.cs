using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3194
{
    public class Solution3194 : Interface3194
    {
        public double MinimumAverage(int[] nums)
        {
            Array.Sort(nums);

            int l = 0, r = nums.Length - 1;
            double result = ((double)nums[l] + nums[r]) / 2;
            while ((++l) < (--r)) result = Math.Min(result, ((double)nums[l] + nums[r]) / 2);

            return result;
        }
    }
}
