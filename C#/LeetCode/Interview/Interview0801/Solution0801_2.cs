using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0801
{
    public class Solution0801_2 : Interface0801
    {
        /// <summary>
        /// 矩阵快速幂
        /// 具体见Solution0801.md
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int WaysToStep(int n)
        {
            if (n < 4) return 1 << (n - 1);

            const int MOD = (int)1e9 + 7;
            int[,] matrix = new int[3, 3] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };
            matrix = PowMatrix(matrix, n - 3, MOD);

            return (((((matrix[0, 0] << 1) % MOD) << 1) % MOD + (matrix[0, 1] << 1) % MOD) % MOD + matrix[0, 2]) % MOD;
        }

        private int[,] PowMatrix(int[,] matrix, int n, int MOD)
        {
            Dictionary<int, int[,]> map = new Dictionary<int, int[,]>();
            int len = matrix.GetLength(0);
            int[,] _matrix = new int[len, len];
            for (int r = 0; r < len; r++) for (int c = 0; c < len; c++) _matrix[r, c] = matrix[r, c];
            map.Add(1, _matrix);

            int _n = 1; int _val;
            while ((_n << 1) <= n)
            {
                _matrix = new int[len, len];
                for (int r = 0; r < len; r++) for (int c = 0; c < len; c++)
                    {
                        _val = 0;
                        for (int i = 0; i < len; i++) _val = (_val + (int)(((long)map[_n][r, i]) * map[_n][i, c] % MOD)) % MOD;
                        _matrix[r, c] = _val;
                    }
                map.Add(_n << 1, _matrix);
                _n <<= 1;
            }

            int[,] result = new int[len, len];
            for (int i = 0; i < len; i++) result[i, i] = 1;
            int pos = 1; _n = n;
            while (_n > 0)
            {
                if ((_n & 1) == 1)
                {
                    _matrix = new int[len, len];
                    for (int r = 0; r < len; r++) for (int c = 0; c < len; c++)
                        {
                            _val = 0;
                            for (int i = 0; i < len; i++) _val = (_val + (int)((long)result[r, i] * map[pos][i, c] % MOD)) % MOD;
                            _matrix[r, c] = _val;
                        }
                    result = _matrix;
                }
                _n >>= 1; pos <<= 1;
            }

            return result;
        }
    }
}
