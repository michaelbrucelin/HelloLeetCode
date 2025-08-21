using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1504
{
    public class Solution1504_2 : Interface1504
    {
        /// <summary>
        /// DP，类前缀和
        /// 令F(x,y)表示mat[x][y]上方连续1的数量，则可以快速计算出以mat[x][y]为右下角的矩形的数量
        /// 宽度为1的矩形的数量：F(x,y)
        /// 宽度为2的矩形的数量：Min(F(x,y), F(x,y-1))
        /// 宽度为3的矩形的数量：Min(F(x,y), F(x,y-1), F(x,y-2))
        /// ... ...
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSubmat(int[][] mat)
        {
            int result = 0, rcnt = mat.Length, ccnt = mat[0].Length;
            int[,] dp = new int[rcnt + 1, ccnt];
            int height;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (mat[r][c] == 1)
                    {
                        height = dp[r + 1, c] = dp[r, c] + 1;
                        for (int _c = c; _c >= 0 && dp[r + 1, _c] > 0; _c--)
                        {
                            height = Math.Min(height, dp[r + 1, _c]);
                            result += height;
                        }
                    }

            return result;
        }
    }
}
