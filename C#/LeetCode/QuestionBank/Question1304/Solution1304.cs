using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1304
{
    public class Solution1304 : Interface1304
    {
        public int[] SumZero(int n)
        {
            int[] result = new int[n];
            int limit = n >> 1, ptr = n & 1;
            for (int i = 1; i <= limit; i++)
            {
                result[ptr++] = i; result[ptr++] = -i;
            }

            return result;
        }
    }
}
