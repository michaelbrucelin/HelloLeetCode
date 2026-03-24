using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2906
{
    public class Solution2906_2 : Interface2906
    {
        /// <summary>
        /// 分块
        /// 假定grid的size是m*n，将grid分为大小的x*y的矩阵块，则每一个位置需要计算m/x * n/y + x*y次
        /// 显然，将grid分为大小的sqrt(m)*sqrt(n)的矩阵块时间复杂度最低
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] ConstructProductMatrix(int[][] grid)
        {
            int mod = 12345, rcnt = grid.Length, ccnt = grid[0].Length;
            int cr = (int)Math.Ceiling(Math.Sqrt(rcnt)), cc = (int)Math.Ceiling(Math.Sqrt(ccnt));
            int[][] chunk = new int[cr][];
            for (int r = 0; r < cr; r++) chunk[r] = new int[cc];
            long x;
            for (int _r = 0; _r < cr; _r++) for (int _c = 0; _c < cc; _c++)
                {
                    x = 1;
                    for (int r = _r * cr, R = Math.Min(rcnt, (_r + 1) * cr); r < R; r++) for (int c = _c * cc, C = Math.Min(ccnt, (_c + 1) * cc); c < C; c++)
                        {
                            x = x * grid[r][c] % mod;
                        }
                    chunk[_r][_c] = (int)x;
                }

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            int nr, nc;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    x = 1; nr = r / cr; nc = c / cc;
                    for (int _r = 0; _r < cr; _r++) for (int _c = 0; _c < cc; _c++)
                        {
                            if (_r == nr && _c == nc) continue;
                            x = x * chunk[_r][_c] % mod;
                        }
                    for (int _r = nr * cr, R = Math.Min(rcnt, (nr + 1) * cr); _r < R; _r++) for (int _c = nc * cc, C = Math.Min(ccnt, (nc + 1) * cc); _c < C; _c++)
                        {
                            if (_r == r && _c == c) continue;
                            x = x * grid[_r][_c] % mod;
                        }
                    result[r][c] = (int)x;
                }

            return result;
        }
    }
}
