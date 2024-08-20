using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0552
{
    public class Solution0552_3 : Interface0552
    {
        /// <summary>
        /// 逻辑同Solution0552_2，改为使用迭代实现矩阵快速幂
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
            long[,] matrix = new long[,] { { 1, 0, 0, 0, 0, 0, 0 },
                                           { 0, 1, 0, 0, 0, 0, 0 },
                                           { 0, 0, 1, 0, 0, 0, 0 },
                                           { 0, 0, 0, 1, 0, 0, 0 },
                                           { 0, 0, 0, 0, 1, 0, 0 },
                                           { 0, 0, 0, 0, 0, 1, 0 },
                                           { 0, 0, 0, 0, 0, 0, 1 } };

            n--;
            while (n > 0)
            {
                if ((n & 1) == 1) matrix = MatrixMul(matrix, matrix0);
                matrix0 = MatrixMul(matrix0, matrix0);
                n >>= 1;
            }

            long[] dp0 = { 1, 0, 0, 0, 1, 1, 0 }, dp = new long[7];
            for (int i = 0; i < 7; i++) for (int j = 0; j < 7; j++) dp[i] += matrix[i, j] * dp0[j];

            return (int)(dp.Sum() % MOD);

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
