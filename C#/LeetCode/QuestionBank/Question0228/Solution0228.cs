using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0228
{
    public class Solution0228 : Interface0228
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> result = new List<string>();
            if (nums.Length == 0) return result;
            if (nums.Length == 1) { result.Add(nums[0].ToString()); return result; }

            int id = 0, len = nums.Length, start = nums[0];
            while (++id < len)
            {
                if (nums[id] == nums[id - 1] + 1) continue;

                result.Add(nums[id - 1] == start ? start.ToString() : $"{start}->{nums[id - 1]}");
                start = nums[id];
            }
            result.Add(nums[len - 1] == start ? start.ToString() : $"{start}->{nums[len - 1]}");

            return result;
        }
    }
}
