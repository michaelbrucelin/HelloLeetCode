using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0127
{
    public class Solution0127_3 : Interface0127
    {
        /// <summary>
        /// 矩阵快速幂
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int TrainWays(int num)
        {
            if (num == 0) return 1; else if (num < 3) return num;

            const int MOD = (int)1e9 + 7;
            long[,] unit = { { 1, 1 }, { 1, 0 } }, _temp = new long[2, 2];
            long[,] matrix = { { 1, 0 }, { 0, 1 } };
            num -= 2;
            while (num > 0)
            {
                if ((num & 1) == 1)
                {
                    for (int r = 0; r < 2; r++) for (int c = 0; c < 2; c++)
                        {
                            _temp[r, c] = 0; for (int i = 0; i < 2; i++) _temp[r, c] += matrix[r, i] * unit[i, c] % MOD;
                        }
                    for (int r = 0; r < 2; r++) for (int c = 0; c < 2; c++) matrix[r, c] = _temp[r, c] % MOD;
                }

                for (int r = 0; r < 2; r++) for (int c = 0; c < 2; c++)
                    {
                        _temp[r, c] = 0; for (int i = 0; i < 2; i++) _temp[r, c] += unit[r, i] * unit[i, c] % MOD;
                    }
                for (int r = 0; r < 2; r++) for (int c = 0; c < 2; c++) unit[r, c] = _temp[r, c] % MOD;

                num >>= 1;
            }

            return (int)(((matrix[0, 0] << 1) % MOD + matrix[0, 1]) % MOD);
        }
    }
}
