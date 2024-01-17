using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2639
{
    public class Solution2639 : Interface2639
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindColumnWidth(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] result = new int[ccnt];
            for (int c = 0; c < ccnt; c++) for (int r = 0; r < rcnt; r++)
                {
                    result[c] = Math.Max(result[c], grid[r][c].ToString().Length);
                }

            return result;
        }

        /// <summary>
        /// 同FindColumnWidth()，只是将计算“数字宽度”改为了数学计算
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindColumnWidth2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] result = new int[ccnt];
            for (int c = 0; c < ccnt; c++) for (int r = 0; r < rcnt; r++)
                {
                    result[c] = Math.Max(result[c], NumWidth(grid[r][c]));
                }

            return result;
        }

        private int NumWidth(int num)
        {
            if (num == 0) return 1;

            int width = 0;
            if (num < 0) { width = 1; num = -num; }

            while (num > 0) { width++; num /= 10; }

            return width;
        }

        /// <summary>
        /// 同FindColumnWidth()，只是将计算“数字宽度”改为了数学计算
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindColumnWidth3(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] result = new int[ccnt];
            for (int c = 0; c < ccnt; c++) for (int r = 0; r < rcnt; r++)
                {
                    result[c] = Math.Max(result[c], NumWidth3(grid[r][c]));
                }

            return result;
        }

        private int NumWidth3(int num)
        {
            if (num == 0) return 1;

            return (int)Math.Log10(Math.Abs(num)) + (num < 0 ? 2 : 1);
        }
    }
}
