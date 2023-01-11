using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0260
{
    public class Solution0260 : Interface0260
    {
        public int[] SingleNumber(int[] nums)
        {
            if (nums.Length == 2) return nums;

            int xorsum = nums[0];
            for (int i = 1; i < nums.Length; i++) xorsum ^= nums[i];

            int pos = 0; while (((xorsum >> pos) & 1) != 1) pos++;  // 一定有解，不必担心溢出
            int xor0 = 0, xor1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (((nums[i] >> pos) & 1) != 1) xor0 ^= nums[i]; else xor1 ^= nums[i];
            }

            return new int[] { xor0, xor1 };
        }
    }
}
