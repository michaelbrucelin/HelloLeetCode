using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1411
{
    public class Solution1141_2 : Interface1411
    {
        /// <summary>
        /// 矩阵快速幂
        /// 逻辑同Solution1411，使用矩阵快速幂加速试一试效果
        /// |F(N,2)|_|3 2|^{N-1}|6|
        /// |F(N,3)|~|2 2|      |6|
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumOfWays(int n)
        {
            if (n == 1) return 12;

            const int MOD = (int)1e9 + 7;
            if (n < 16)
            {
                long cnt2 = 6, cnt3 = 6;
                while (--n > 0) (cnt2, cnt3) = ((cnt2 * 3 + (cnt3 << 1)) % MOD, ((cnt2 << 1) + (cnt3 << 1)) % MOD);
                return (int)((cnt2 + cnt3) % MOD);
            }
            else
            {
                n--;
                long[,] k = new long[,] { { 1, 0 }, { 0, 1 } };
                long[,] matrix = new long[,] { { 3, 2 }, { 2, 2 } };
                while (n > 0)
                {
                    if ((n & 1) == 1) k = matris_mul(matrix, k);
                    matrix = matris_mul(matrix, matrix);
                    n >>= 1;
                }

                return (int)((0L + k[0, 0] + k[0, 1] + k[1, 0] + k[1, 1]) * 6 % MOD);
            }

            long[,] matris_mul(long[,] m1, long[,] m2)
            {
                long[,] m = new long[2, 2];
                for (int r = 0; r < 2; r++) for (int c = 0; c < 2; c++)
                    {
                        for (int i = 0; i < 2; i++) m[r, c] += m1[r, i] * m2[i, c];
                        m[r, c] %= MOD;
                    }
                return m;
            }
        }
    }
}
