using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2906
{
    public class Solution2906_3 : Interface2906
    {
        /// <summary>
        /// 前后缀处理
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] ConstructProductMatrix(int[][] grid)
        {
            int mod = 12345, rcnt = grid.Length, ccnt = grid[0].Length;
            int n = rcnt * ccnt;
            int[] pd1 = new int[n]; pd1[0] = 1;
            int[] pd2 = new int[n]; pd2[n - 1] = 1;
            for (int i = 0, r, c, j = n - 1; i < n - 1; i++, j--)
            {
                r = i / ccnt; c = i % ccnt;
                pd1[i + 1] = (int)(1L * pd1[i] * grid[r][c] % mod);
                pd2[j - 1] = (int)(1L * pd2[j] * grid[rcnt - r - 1][ccnt - c - 1] % mod);
            }

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            for (int r = 0, i; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    i = r * ccnt + c;
                    result[r][c] = (int)(1L * pd1[i] * pd2[i] % mod);
                }

            return result;
        }
    }
}
