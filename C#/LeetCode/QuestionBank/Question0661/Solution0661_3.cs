using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0661
{
    public class Solution0661_3 : Interface0661
    {
        /// <summary>
        /// 前缀和
        /// 1. 使用pre1[][]记录img[0][0]-img[i][j]的和
        /// 2. pre2[r+1][c+1] - pre[r-2][c] - pre[r][c-2] + pre[r-2][c-2]就是灰度和
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother(int[][] img)
        {
            int rcnt = img.Length, ccnt = img[0].Length;
            int[][] pre = new int[rcnt + 1][];
            for (int i = 0; i < rcnt + 1; i++) pre[i] = new int[ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1][c + 1] += pre[r][c + 1] + pre[r + 1][c] - pre[r][c] + img[r][c];
                }

            int[][] result = new int[rcnt][];
            for (int i = 0; i < rcnt; i++) result[i] = new int[ccnt];
            int sum, r1, r2, c1, c2;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    r1 = Math.Max(r - 1, 0); r2 = Math.Min(r + 1, rcnt - 1);
                    c1 = Math.Max(c - 1, 0); c2 = Math.Min(c + 1, ccnt - 1);
                    sum = pre[r2 + 1][c2 + 1] - pre[r1][c2 + 1] - pre[r2 + 1][c1] + pre[r1][c1];
                    result[r][c] = sum / ((r2 - r1 + 1) * (c2 - c1 + 1));
                }

            return result;
        }

        /// <summary>
        /// 前缀和
        /// 20241118
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother2(int[][] img)
        {
            int rcnt = img.Length, ccnt = img[0].Length;
            int[,] pre = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1, c + 1] = img[r][c] + pre[r, c + 1] + pre[r + 1, c] - pre[r, c];
                }

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            int r1, r2, c1, c2;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    r1 = Math.Max(r - 1, 0); r2 = Math.Min(r + 2, rcnt);
                    c1 = Math.Max(c - 1, 0); c2 = Math.Min(c + 2, ccnt);
                    result[r][c] = (pre[r2, c2] - pre[r1, c2] - pre[r2, c1] + pre[r1, c1]) / ((r2 - r1) * (c2 - c1));
                }

            return result;
        }
    }
}
