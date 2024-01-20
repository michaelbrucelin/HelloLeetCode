using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2765
{
    public class Solution2765 : Interface2765
    {
        public int AlternatingSubarray(int[] nums)
        {
            int result = -1, _r, p = 0, _p, len = nums.Length;
            while (p < len)
            {
                if (p + 1 < len && nums[p + 1] == nums[p] + 1)
                {
                    _p = p + 1;
                    while (_p + 1 < len && nums[_p + 1] == nums[_p - 1]) _p++;
                    result = Math.Max(result, _p - p + 1);
                    p = _p;
                }
                else
                {
                    p++;
                }
            }

            return result;
        }
    }
}
