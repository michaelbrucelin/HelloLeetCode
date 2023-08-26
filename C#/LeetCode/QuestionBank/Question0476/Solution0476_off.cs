using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0476
{
    public class Solution0476_off : Interface0476
    {
        public int FindComplement(int num)
        {
            int bits = 0, left = 0, right = 30, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (num >= (1 << mid))
                {
                    bits = mid + 1; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (bits == 31) return int.MaxValue ^ num;
            return ((1 << bits) - 1) ^ num;
        }
    }
}
