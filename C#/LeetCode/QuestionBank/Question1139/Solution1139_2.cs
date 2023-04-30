using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1139
{
    public class Solution1139_2 : Interface1139
    {
        /// <summary>
        /// 本质上与Solution1139一样，但是做了预处理，这样会更快，具体见Solution1139.md
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int Largest1BorderedSquare(int[][] grid)
        {
            int width = grid[0].Length, height = grid.Length;
            int[,,] dp = new int[height + 1, width + 1, 2];  // dp[,,0]是向右，dp[,,1]是向下
            for (int r = height - 1; r >= 0; r--) for (int c = width - 1; c >= 0; c--)
                {
                    if (grid[r][c] != 0)
                    {
                        dp[r, c, 0] = dp[r, c + 1, 0] + 1; dp[r, c, 1] = dp[r + 1, c, 1] + 1;
                    }
                    else
                    {
                        dp[r, c, 0] = 0; dp[r, c, 1] = 0;
                    }
                }

            int result = 0;
            for (int r = 0; r < height; r++)
            {
                if (height - r <= result) break;
                for (int c = 0; c < width; c++)
                {
                    if (width - c <= result) break;
                    int len = Math.Min(dp[r, c, 0], dp[r, c, 1]);
                    while (len > result)
                    {
                        if (dp[r + len - 1, c, 0] >= len && dp[r, c + len - 1, 1] >= len)
                        {
                            result = len; break;
                        }
                        else
                        {
                            len--;
                        }
                    }
                }
            }

            return result * result;
        }
    }
}
