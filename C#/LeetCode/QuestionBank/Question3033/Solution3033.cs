using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3033
{
    public class Solution3033 : Interface3033
    {
        public int[][] ModifiedMatrix(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];

            List<int> mask = new List<int>(); int max;
            for (int c = 0; c < ccnt; c++)
            {
                mask.Clear(); max = -2;
                for (int r = 0; r < rcnt; r++)
                {
                    result[r][c] = matrix[r][c]; max = Math.Max(max, matrix[r][c]);
                    if (matrix[r][c] == -1) mask.Add(r);
                }
                foreach (int r in mask) result[r][c] = max;
            }

            return result;
        }
    }
}
