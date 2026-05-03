using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0357
{
    public class Solution0357_dial : Interface0357
    {
        private static readonly int[] map = [1, 10, 91, 739, 5275, 32491, 168571, 712891, 2345851];

        public int CountNumbersWithUniqueDigits(int n)
        {
            return map[n];
        }
    }
}
