using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0688
{
    public class Solution0688_off : Interface0688
    {
        private static readonly (int r, int c)[] dirs = [(2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2)];

        public double KnightProbability(int n, int k, int row, int column)
        {
            if (k == 0) return 1D;

            double[,] dp = new double[n, n], _dp = new double[n, n];
            dp[row, column] = 1D;
            while (k-- > 0)
            {
                for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    {
                        for (int j = 0, _r, _c; j < 8; j++)
                        {
                            _r = r + dirs[j].r; _c = c + dirs[j].c;
                            if (_r >= 0 && _r < n && _c >= 0 && _c < n)
                            {
                                _dp[_r, _c] += dp[r, c] / 8;
                            }
                        }
                    }

                for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    {
                        dp[r, c] = _dp[r, c]; _dp[r, c] = 0;
                    }
            }

            double result = 0;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) result += dp[r, c];
            return result;
        }
    }
}
