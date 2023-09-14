using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0762
{
    public class Solution0762 : Interface0762
    {
        private static readonly HashSet<int> prime = new HashSet<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

        public int CountPrimeSetBits(int left, int right)
        {
            int result = 0;
            for (int i = left; i <= right; i++) if (prime.Contains(BitCount(i))) result++;

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
    }
}
