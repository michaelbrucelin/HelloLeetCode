using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0762
{
    public class Solution0762_2 : Interface0762
    {
        private static readonly HashSet<int> prime = new HashSet<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        private const int M01 = 0B01010101010101010101010101010101;
        private const int M02 = 0B00110011001100110011001100110011;
        private const int M04 = 0B00001111000011110000111100001111;
        private const int M08 = 0B00000000111111110000000011111111;
        private const int M16 = 0B00000000000000001111111111111111;

        public int CountPrimeSetBits(int left, int right)
        {
            int result = 0;
            for (int i = left; i <= right; i++) if (prime.Contains(BitCount(i))) result++;

            return result;

            static int BitCount(int x)
            {
                x = (x & M01) + ((x >> 1) & M01);
                x = (x & M02) + ((x >> 2) & M02);
                x = (x & M04) + ((x >> 4) & M04);
                x = (x & M08) + ((x >> 8) & M08);
                return (x & M16) + ((x >> 16) & M16);
            }
        }
    }
}
