using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0260
{
    public class Solution0260_3 : Interface0260
    {
        public int[] SingleNumber(int[] nums)
        {
            if (nums.Length == 2) return nums;

            int xorsum = 0;
            foreach (int num in nums) xorsum ^= num;

            int lsb = (xorsum == int.MinValue ? xorsum : xorsum & (-xorsum));  // 防止溢出
            int xor1 = 0, xor2 = 0;
            foreach (int num in nums)
            {
                if ((num & lsb) != 0) xor1 ^= num; else xor2 ^= num;
            }

            return new int[] { xor1, xor2 };
        }
    }
}
