using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2859
{
    public class Solution2859 : Interface2859
    {
        public int SumIndicesWithKSetBits(IList<int> nums, int k)
        {
            int result = 0;
            for (int i = 0; i < nums.Count; i++)
                if (BitCount(i) == k) result += nums[i];

            return result;
        }

        private int BitCount(int u)
        {
            int result = 0;

            while (u > 0)
            {
                result++; u &= u - 1;
            }

            return result;
        }

        private int HammingWeight(long n)
        {
            long result = n - ((n >> 1) & 3681400539) - ((n >> 2) & 1227133513);

            return (int)(((result + (result >> 3)) & 3340530119) % 63);
        }
    }
}
