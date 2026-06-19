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
            int[,] sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1] = sums[r, c + 1] + sums[r + 1, c] - sums[r, c] + matrix[r][c];
                }

            throw new NotImplementedException();
        }
    }
}
