using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1292
{
    public class Solution1292_2 : Interface1292
    {
        /// <summary>
        /// 前缀和
        /// 逻辑同Solution1292，将最内层的二分改为遍历，就是使用双指针代替二分的思路
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int MaxSideLength(int[][] mat, int threshold)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[,] sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) sums[r + 1, c + 1] = sums[r + 1, c] + sums[r, c + 1] - sums[r, c] + mat[r][c];
            if (sums[rcnt, ccnt] <= threshold) return Math.Min(rcnt, ccnt);

            int result = 0, sum, low, high, mid;
            for (int r = 0; r + result < rcnt; r++) for (int c = 0; r + result < rcnt & c + result < ccnt; c++)
                {
                    low = result; high = Math.Min(rcnt - r, ccnt - c) - 1;
                    for (int i = low; i <= high; i++)
                    {
                        sum = sums[r + i + 1, c + i + 1] - sums[r + i + 1, c] - sums[r, c + i + 1] + sums[r, c];
                        if (sum <= threshold) result++;
                    }
                }

            return result;
        }
    }
}
