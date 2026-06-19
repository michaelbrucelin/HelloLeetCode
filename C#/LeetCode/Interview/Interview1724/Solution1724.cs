using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1724
{
    public class Solution1724 : Interface1724
    {
        /// <summary>
        /// 二维前缀和
        /// 借助二维前缀和暴力查找
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] GetMaxMatrix(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            long[,] sums = new long[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1] = sums[r, c + 1] + sums[r + 1, c] - sums[r, c] + matrix[r][c];
                }

            long max = matrix[0][0], sum;
            int[] result = [0, 0, 0, 0];
            for (int r1 = 0; r1 < rcnt; r1++) for (int c1 = 0; c1 < ccnt; c1++)
                {
                    for (int r2 = r1; r2 < rcnt; r2++) for (int c2 = c1; c2 < ccnt; c2++)
                        {
                            sum = sums[r2 + 1, c2 + 1] - sums[r1, c2 + 1] - sums[r2 + 1, c1] + sums[r1, c1];
                            if (sum > max)
                            {
                                result[0] = r1; result[1] = c1; result[2] = r2; result[3] = c2;
                                max = sum;
                            }
                        }
                }

            return result;
        }
    }
}
