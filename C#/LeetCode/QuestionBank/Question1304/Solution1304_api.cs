using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1304
{
    public class Solution1304_api : Interface1304
    {
        public int[] SumZero(int n)
        {
            return Enumerable.Range(2 - (n & 1), n)
                             .Select(i => (int)Math.Pow(-1, i) * ((i - (i & 1)) >> 1))
                             .ToArray();
        }
    }
}
