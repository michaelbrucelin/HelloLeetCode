using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3882
{
    public class Solution3882 : Interface3882
    {
        /// <summary>
        /// DP
        /// 最多有1000个单元格，每个单元格最多有1024个状态，本质上依然是暴力枚举
        /// 
        /// 如果为了节省空间，可以改为滚动数组，还可以考虑沿着维度大的方向滚动数组，这里就不做了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinCost(int[][] grid)
        {
            int xor = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 0) { for (int i = 0; i < ccnt; i++) xor ^= grid[0][i]; return xor; }
            if (ccnt == 0) { for (int i = 0; i < rcnt; i++) xor ^= grid[i][0]; return xor; }

            HashSet<int>[,] sets = new HashSet<int>[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) sets[r, c] = new HashSet<int>();
            sets[0, 0].Add(grid[0][0]);
            for (int c = 1; c < ccnt; c++) foreach (int x in sets[0, c - 1]) sets[0, c].Add(x ^ grid[0][c]);
            for (int r = 1; r < rcnt; r++) foreach (int x in sets[r - 1, 0]) sets[r, 0].Add(x ^ grid[r][0]);
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    foreach (int x in sets[r - 1, c]) sets[r, c].Add(x ^ grid[r][c]);
                    foreach (int x in sets[r, c - 1]) sets[r, c].Add(x ^ grid[r][c]);
                }

            xor = 1024;
            foreach (int x in sets[rcnt - 1, ccnt - 1]) xor = Math.Min(xor, x);
            return xor;
        }

        /// <summary>
        /// 逻辑完全同MinCost()，将Hash改为数组，数组还是比Hash快很多
        /// 
        /// 如果为了节省空间，可以改为滚动数组，还可以考虑沿着维度大的方向滚动数组，这里就不做了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinCost2(int[][] grid)
        {
            int xor = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 0) { for (int i = 0; i < ccnt; i++) xor ^= grid[0][i]; return xor; }
            if (ccnt == 0) { for (int i = 0; i < rcnt; i++) xor ^= grid[i][0]; return xor; }

            bool[,,] sets = new bool[rcnt, ccnt, 1024];
            sets[0, 0, grid[0][0]] = true;
            for (int c = 1; c < ccnt; c++) for (int i = 0; i < 1024; i++) if (sets[0, c - 1, i]) sets[0, c, i ^ grid[0][c]] = true;
            for (int r = 1; r < rcnt; r++) for (int i = 0; i < 1024; i++) if (sets[r - 1, 0, i]) sets[r, 0, i ^ grid[r][0]] = true;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    for (int i = 0; i < 1024; i++) if (sets[r - 1, c, i]) sets[r, c, i ^ grid[r][c]] = true;
                    for (int i = 0; i < 1024; i++) if (sets[r, c - 1, i]) sets[r, c, i ^ grid[r][c]] = true;
                }

            xor = 1024;
            for (int i = 0; i < 1024; i++) if (sets[rcnt - 1, ccnt - 1, i]) xor = Math.Min(xor, i);
            return xor;
        }
    }
}
