using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0338
{
    public class Solution0338_4 : Interface0338
    {
        public int[] CountBits(int n)
        {
            int[] result = new int[n + 1];
            int highBit = 0;
            for (int i = 1; i <= n; i++)
            {
                if ((i & (i - 1)) == 0) highBit = i;
                result[i] = result[i - highBit] + 1;
            }

            return result;
        }
    }
}
