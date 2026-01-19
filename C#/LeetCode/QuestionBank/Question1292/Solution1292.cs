using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1292
{
    public class Solution1292 : Interface1292
    {
        /// <summary>
        /// 二分 + 前缀和
        /// 枚举每个起点（左上），二分查找最大的终点（右下），前缀和优化
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
                    while (low <= high)
                    {
                        mid = low + ((high - low) >> 1);
                        sum = sums[r + mid + 1, c + mid + 1] - sums[r + mid + 1, c] - sums[r, c + mid + 1] + sums[r, c];
                        if (sum <= threshold)
                        {
                            result = Math.Max(result, mid + 1); low = mid + 1;
                        }
                        else
                        {
                            high = mid - 1;
                        }
                    }
                }


            return result;
        }
    }
}
