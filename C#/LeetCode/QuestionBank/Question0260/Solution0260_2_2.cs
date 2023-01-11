using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0260
{
    public class Solution0260_2_2 : Interface0260
    {
        public int[] SingleNumber(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
                if (result.Contains(nums[i])) result.Remove(nums[i]); else result.Add(nums[i]);

            return result.ToArray();
        }
    }
}
