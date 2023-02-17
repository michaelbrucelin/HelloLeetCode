using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1139
{
    public class Solution1139 : Interface1139
    {
        /// <summary>
        /// 暴力解
        /// 具体步骤见Solution1139.md
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int Largest1BorderedSquare(int[][] grid)
        {
            int result = 0, width = grid[0].Length, height = grid.Length;
            for (int r = 0; r < height; r++)
            {
                if (height - r <= result) break;
                for (int c = 0; c < width; c++)
                {
                    if (width - c <= result) break;
                    if (grid[r][c] == 1)
                    {
                        int e = 0;  // e: expand, len: e + 1
                        while (r + e + 1 < height && c + e + 1 < width && grid[r + e + 1][c] == 1 && grid[r][c + e + 1] == 1) e++;
                        while (e + 1 > result)
                        {
                            bool flag = true;
                            for (int i = 1; i <= e; i++)
                            {
                                if (grid[r + e][c + i] != 1 || grid[r + i][c + e] != 1) { flag = false; break; }
                            }

                            if (flag)
                            {
                                result = e + 1; break;  // result = Math.Max(result, e + 1);
                            }
                            else
                            {
                                e--;
                            }
                        }
                    }
                }
            }

            return result * result;
        }
    }
}
