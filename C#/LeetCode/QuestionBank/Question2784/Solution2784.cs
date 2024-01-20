using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2784
{
    public class Solution2784 : Interface2784
    {
        public bool IsGood(int[] nums)
        {
            int len = nums.Length;
            int[] mask = new int[len];
            mask[len - 1] = -1;

            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (num <= 0 || num > len - 1 || mask[num] == 1) return false;
                mask[num]++;
            }

            return true;
        }
    }
}
