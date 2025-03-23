using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2680
{
    public class Solution2680 : Interface2680
    {
        public long MaximumOr(int[] nums, int k)
        {
            int maxid = 0, len = nums.Length;
            for (int i = 1; i < len; i++) if (nums[i] > nums[maxid]) maxid = i;

            long result = 0;
            for (int i = 0; i < maxid; i++) result |= nums[i];
            for (int i = maxid + 1; i < len; i++) result |= nums[i];
            result |= nums[maxid] << k;

            return result;
        }
    }
}
