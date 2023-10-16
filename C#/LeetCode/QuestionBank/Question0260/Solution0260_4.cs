using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0260
{
    public class Solution0260_4 : Interface0260
    {
        public int[] SingleNumber(int[] nums)
        {
            int xor = 0, len = nums.Length;
            for (int i = 0; i < len; i++) xor ^= nums[i];
            int w = -1; while (((xor >> ++w) & 1) == 0) ;

            int[] result = new int[2];
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                result[(num >> w) & 1] ^= num;
            }

            return result;
        }
    }
}
