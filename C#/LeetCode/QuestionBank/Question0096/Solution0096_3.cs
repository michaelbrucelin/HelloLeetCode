using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0096
{
    public class Solution0096_3 : Interface0096
    {
        public int NumTrees(int n)
        {
            return (int)(Factorial(2 * n) / (Factorial(n + 1) * Factorial(n)));
        }

        public BigInteger Factorial(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }
    }
}
