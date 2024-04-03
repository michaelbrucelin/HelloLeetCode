using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3099
{
    public class Solution3099_dial : Interface3099
    {
        private static readonly int[] map = [0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  1, -1,  3, -1, -1, -1, -1, -1,  9, -1,  2,
                                                 3, -1, -1,  6, -1, -1,  9, -1, -1,  3, -1, -1, -1, -1, -1,  9, -1, -1, -1,  4,
                                                -1,  6, -1, -1,  9, -1, -1, 12, -1,  5, -1, -1, -1,  9, -1, -1, -1, -1, -1,  6,
                                                -1, -1,  9, -1, -1, -1, -1, -1, -1,  7, -1,  9, -1, -1, -1, -1, -1, -1, -1,  8,
                                                 9, -1, -1, 12, -1, -1, -1, -1, -1,  9, -1, -1, -1, -1, -1, -1, -1, -1, -1, 1];
        public int SumOfTheDigitsOfHarshadNumber(int x)
        {
            return map[x];
        }
    }
}
