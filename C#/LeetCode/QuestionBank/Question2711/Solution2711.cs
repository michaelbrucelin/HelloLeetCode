using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2711
{
    public class Solution2711 : Interface2711
    {
        /// <summary>
        /// 暴力模拟
        /// 题目限定的数据量较小，暴力模拟不会TLE
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] DifferenceOfDistinctValues(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            HashSet<int> set = new HashSet<int>();

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) result[r][c] = Math.Abs(topleft(r, c) - bottomright(r, c));

            return result;

            int topleft(int r, int c)
            {
                set.Clear();
                while (--r >= 0 && --c >= 0) set.Add(grid[r][c]);
                return set.Count;
            }

            int bottomright(int r, int c)
            {
                set.Clear();
                while (++r < rcnt && ++c < ccnt) set.Add(grid[r][c]);
                return set.Count;
            }
        }

        /// <summary>
        /// 逻辑同DifferenceOfDistinctValues()，将HashSet计数改为位运算
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] DifferenceOfDistinctValues2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) result[r][c] = Math.Abs(topleft(r, c) - bottomright(r, c));

            return result;

            int topleft(int r, int c)
            {
                long mask = 0;
                while (--r >= 0 && --c >= 0) mask |= 1L << grid[r][c];
                return count1(mask);
            }

            int bottomright(int r, int c)
            {
                long mask = 0;
                while (++r < rcnt && ++c < ccnt) mask |= 1L << grid[r][c];
                return count1(mask);
            }

            int count1(long n)
            {
                int cnt = 0;
                while (n > 0) { n &= n - 1; cnt++; }
                return cnt;
            }
        }
    }
}
