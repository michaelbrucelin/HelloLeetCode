using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169_6 : Interface0169
    {
        public int MajorityElement(int[] nums)
        {
            int candidate = nums[0], cnt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (cnt == 0) candidate = nums[i];
                cnt += nums[i] == candidate ? 1 : -1;
            }

            return candidate;
        }
    }
}
