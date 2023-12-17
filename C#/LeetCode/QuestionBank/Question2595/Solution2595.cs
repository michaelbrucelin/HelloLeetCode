using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2595
{
    public class Solution2595 : Interface2595
    {
        public int[] EvenOddBit(int n)
        {
            int[] result = new int[2];
            int id = 0;
            while (n > 0)
            {
                result[id] += n & 1; n >>= 1; id ^= 1;
            }

            return result;
        }
    }
}
