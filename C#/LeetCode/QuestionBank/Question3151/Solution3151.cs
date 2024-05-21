using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3151
{
    public class Solution3151 : Interface3151
    {
        public bool IsArraySpecial(int[] nums)
        {
            if (nums.Length == 1) return true;
            for (int i = 1; i < nums.Length; i++)
                if ((nums[i - 1] & 1) + (nums[i] & 1) != 1) return false;

            return true;
        }
    }
}
