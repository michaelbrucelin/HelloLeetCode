using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1664
{
    public class Solution1664_2 : Interface1664
    {
        public int WaysToMakeFair(int[] nums)
        {
            int pre_odd = 0, pre_even = 0, suf_odd = 0, suf_even = 0;
            for (int i = 1; i < nums.Length; i++) if ((i & 1) != 1) suf_odd += nums[i]; else suf_even += nums[i];

            int result = suf_odd == suf_even ? 1 : 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if ((i & 1) != 1)
                {
                    pre_even += nums[i - 1];
                    suf_odd -= nums[i];
                }
                else
                {
                    pre_odd += nums[i - 1];
                    suf_even -= nums[i];
                }

                if (pre_odd + suf_even == suf_odd + pre_even) result++;
            }

            return result;
        }
    }
}
