using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1504
{
    public class Solution1504 : Interface1504
    {
        /// <summary>
        /// 枚举
        /// 枚举每一个m*n的可能，可以借助二维前缀和加速判断
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSubmat(int[][] mat)
        {
            int result = 0, rcnt = mat.Length, ccnt = mat[0].Length;
            int[,] sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1] = sums[r, c + 1] + sums[r + 1, c] - sums[r, c] + mat[r][c];
                }

            int cnt;
            for (int h = 1; h <= rcnt; h++) for (int w = 1; w <= ccnt; w++)
                {
                    cnt = w * h;
                    for (int r = h - 1; r < rcnt; r++) for (int c = w - 1; c < ccnt; c++)
                        {
                            if (sums[r + 1, c + 1] - sums[r - h + 1, c + 1] - sums[r + 1, c - w + 1] + sums[r - h + 1, c - w + 1] == cnt) result++;
                        }
                }

            return result;
        }
    }
}
