using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0126
{
    public class Solution0126_2 : Interface0126
    {
        /// <summary>
        /// 矩阵快速幂
        /// F2   1  1   F1
        ///    =      *
        /// F1   1  0   F0
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            if (n < 2) return n;

            const int MOD = (int)1e9 + 7;
            long[,] coeff = new long[,] { { 1, 0 }, { 0, 1 } }, matrix = new long[,] { { 1, 1 }, { 1, 0 } };
            n--;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    coeff = new long[,] {{ (coeff[0,0] * matrix[0,0] + coeff[0,1] * matrix[1,0])%MOD, (coeff[0,0] * matrix[1,0] + coeff[0,1] * matrix[1,1])%MOD },
                                         { (coeff[1,0] * matrix[0,0] + coeff[1,1] * matrix[1,0])%MOD, (coeff[1,0] * matrix[1,0] + coeff[1,1] * matrix[1,1])%MOD }};
                }
                matrix = new long[,] {{ (matrix[0,0] * matrix[0,0] + matrix[0,1] * matrix[1,0])%MOD, (matrix[0,0] * matrix[1,0] + matrix[0,1] * matrix[1,1])%MOD },
                                      { (matrix[1,0] * matrix[0,0] + matrix[1,1] * matrix[1,0])%MOD, (matrix[1,0] * matrix[1,0] + matrix[1,1] * matrix[1,1])%MOD }};
                n >>= 1;
            }

            return (int)coeff[0, 0];
        }
    }
}
