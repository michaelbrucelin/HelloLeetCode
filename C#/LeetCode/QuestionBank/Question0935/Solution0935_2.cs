using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0935
{
    public class Solution0935_2 : Interface0935
    {
        /// <summary>
        /// 矩阵快速幂
        ///          0 1 2 3 4 5 6 7 8 9                                N-1
        /// 0        0 0 0 0 1 0 1 0 0 0            0 0 0 0 1 0 1 0 0 0
        /// 1        0 0 0 0 0 0 1 0 1 0            0 0 0 0 0 0 1 0 1 0
        /// 2        0 0 0 0 0 0 0 1 0 1            0 0 0 0 0 0 0 1 0 1
        /// 3        0 0 0 0 1 0 0 0 1 0            0 0 0 0 1 0 0 0 1 0
        /// 4 F(N) = 1 0 0 1 0 0 0 0 0 1 * F(N-1) = 1 0 0 1 0 0 0 0 0 1     * F(1)
        /// 5        0 0 0 0 0 0 0 0 0 0            0 0 0 0 0 0 0 0 0 0
        /// 6        1 1 0 0 0 0 0 1 0 0            1 1 0 0 0 0 0 1 0 0
        /// 7        0 0 1 0 0 0 1 0 0 0            0 0 1 0 0 0 1 0 0 0
        /// 8        0 1 0 1 0 0 0 0 0 0            0 1 0 1 0 0 0 0 0 0
        /// 9        0 0 1 0 1 0 0 0 0 0            0 0 1 0 1 0 0 0 0 0
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int KnightDialer(int n)
        {
            if (n == 1) return 10; n--;
            const int MOD = (int)1e9 + 7;

            long[,] matrix =  { { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 } };
            long[,] _matrix = { { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 }, { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 }, { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0 }, { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 1, 1, 0, 0, 0, 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 }, { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 } };
            while (n > 0)
            {
                if ((n & 1) == 1) matrix = matrix_multiply(matrix, _matrix);
                _matrix = matrix_multiply(_matrix, _matrix);
                n >>= 1;
            }

            long result = 0;
            for (int r = 0; r < 10; r++) for (int c = 0; c < 10; c++) result = (result + matrix[r, c]) % MOD;
            return (int)result;

            long[,] matrix_multiply(long[,] m1, long[,] m2)
            {
                long[,] matrix = new long[10, 10];
                for (int r = 0; r < 10; r++) for (int c = 0; c < 10; c++)
                    {
                        long val = 0;
                        for (int i = 0; i < 10; i++) val = (val + m1[r, i] * m2[i, c]) % MOD;
                        matrix[r, c] = val;
                    }
                return matrix;
            }
        }
    }
}
