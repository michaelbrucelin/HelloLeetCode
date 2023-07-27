using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1314
{
    public class Solution1314 : Interface1314
    {
        public int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[][] pre = new int[rcnt + 1][];
            for (int r = 0; r <= rcnt; r++) pre[r] = new int[ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1][c + 1] = pre[r + 1][c] + pre[r][c + 1] - pre[r][c] + mat[r][c];
                }

            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            int r1, c1, r2, c2;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    r1 = Math.Max(r - k, 0); r2 = Math.Min(r + k, rcnt - 1);
                    c1 = Math.Max(c - k, 0); c2 = Math.Min(c + k, ccnt - 1);
                    result[r][c] = pre[r2 + 1][c2 + 1] - pre[r2 + 1][c1] - pre[r1][c2 + 1] + pre[r1][c1];
                }
            return result;
        }
    }
}
