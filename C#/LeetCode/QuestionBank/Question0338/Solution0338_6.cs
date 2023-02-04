using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0338
{
    public class Solution0338_6 : Interface0338
    {
        public int[] CountBits(int n)
        {
            int[] result = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                result[i] = result[i & (i - 1)] + 1;
            }

            return result;
        }
    }
}
