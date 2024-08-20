using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0552
{
    public class Solution0552_2 : Interface0552
    {
        /// <summary>
        /// 逻辑完全同Solution0552，使用矩阵快速幂技巧加速
        /// 分治实现矩阵快速幂
        /// 
        /// ... ...竟然在 n = 21230 时TLE了，猜测是递归导致的，换迭代实现矩阵快速幂试试
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CheckRecord(int n)
        {
            if (n == 1) return 3;

            const int MOD = (int)1e9 + 7;
            long[,] matrix0 = new long[,] { { 0, 0, 0, 0, 1, 1, 1 },
                                            { 1, 1, 1, 1, 0, 0, 0 },
                                            { 1, 1, 0, 0, 0, 0, 0 },
                                            { 0, 0, 1, 0, 0, 0, 0 },
                                            { 0, 0, 0, 0, 1, 1, 1 },
                                            { 0, 0, 0, 0, 1, 0, 0 },
                                            { 0, 0, 0, 0, 0, 1, 0 } };

            long[,] matrix = MatrixPow(matrix0, n - 1);
            long[] dp0 = { 1, 0, 0, 0, 1, 1, 0 }, dp = new long[7];
            for (int i = 0; i < 7; i++) for (int j = 0; j < 7; j++) dp[i] += matrix[i, j] * dp0[j];

            return (int)(dp.Sum() % MOD);

            long[,] MatrixPow(long[,] matrix, int n)
            {
                if (n == 1) return matrix;
                if (n == 2) return MatrixMul(matrix, matrix);
                if ((n & 1) == 0)
                    return MatrixMul(MatrixPow(matrix, n >> 1), MatrixPow(matrix, n >> 1));
                else
                    return MatrixMul(MatrixMul(MatrixPow(matrix, n >> 1), MatrixPow(matrix, n >> 1)), matrix);
            }

            long[,] MatrixMul(long[,] m1, long[,] m2)
            {
                int m = m1.GetLength(0), n = m2.GetLength(1), k = m1.GetLength(1);
                long[,] result = new long[m, n];
                for (int _m = 0; _m < m; _m++) for (int _n = 0; _n < n; _n++)
                    {
                        long val = 0;
                        for (int _k = 0; _k < k; _k++) val += m1[_m, _k] * m2[_k, _n] % MOD;
                        result[_m, _n] = val % MOD;
                    }

                return result;
            }
        }
    }
}
