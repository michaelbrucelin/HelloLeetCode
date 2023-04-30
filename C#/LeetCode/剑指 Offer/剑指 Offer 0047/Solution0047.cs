using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0047
{
    public class Solution0047 : Interface0047
    {
        /// <summary>
        /// 递归
        /// 提交会超时，参照测试用例4
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 1 || ccnt == 1) return grid.Sum(arr => arr.Sum());

            return rec(grid, rcnt, ccnt, rcnt - 1, ccnt - 1);
        }

        private int rec(int[][] grid, int rcnt, int ccnt, int r, int c)
        {
            if (r == 0 && c == 0) return grid[0][0];
            if (r == 0) return grid[0][c] + rec(grid, rcnt, ccnt, 0, c - 1);
            if (c == 0) return grid[r][0] + rec(grid, rcnt, ccnt, r - 1, 0);
            return grid[r][c] + Math.Max(rec(grid, rcnt, ccnt, r, c - 1), rec(grid, rcnt, ccnt, r - 1, c));
        }

        /// <summary>
        /// 递归 + 记忆化搜索
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 1 || ccnt == 1) return grid.Sum(arr => arr.Sum());

            int[,] memory = new int[rcnt, ccnt];
            for (int i = 0, sum = 0; i < ccnt; i++) { sum += grid[0][i]; memory[0, i] = sum; }  // 第一行只能向前移动
            for (int i = 0, sum = 0; i < rcnt; i++) { sum += grid[i][0]; memory[i, 0] = sum; }  // 第一列只能向下移动
            return rec2(grid, rcnt, ccnt, memory, rcnt - 1, ccnt - 1);
        }

        private int rec2(int[][] grid, int rcnt, int ccnt, int[,] memory, int r, int c)
        {
            if (r == 0 || c == 0 || memory[r, c] > 0) return memory[r, c];

            int up, left;
            if (memory[r - 1, c] > 0) up = memory[r - 1, c];
            else
            {
                up = rec2(grid, rcnt, ccnt, memory, r - 1, c); memory[r - 1, c] = up;
            }
            if (memory[r, c - 1] > 0) left = memory[r, c - 1];
            else
            {
                left = rec2(grid, rcnt, ccnt, memory, r, c - 1); memory[r, c - 1] = left;
            }

            memory[r, c] = grid[r][c] + Math.Max(up, left);
            return memory[r, c];
        }
    }
}
