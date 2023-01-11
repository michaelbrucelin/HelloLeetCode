using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0137
{
    public class Solution0137_3 : Interface0137
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int bits = 0;
                for (int j = 0; j < nums.Length; j++) bits += (nums[j] >> i) & 1;
                if (bits % 3 != 0) result |= 1 << i;
            }

            return result;
        }
    }
}
