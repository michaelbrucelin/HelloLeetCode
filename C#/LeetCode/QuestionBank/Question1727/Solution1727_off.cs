using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1727
{
    public class Solution1727_off : Interface1727
    {
        public int LargestSubmatrix(int[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[] height = new int[ccnt], _height = new int[ccnt];
            Comparer<int> comparer = Comparer<int>.Create((x, y) => y - x);
            for (int r = 0; r < rcnt; r++)
            {
                for (int c = 0; c < ccnt; c++) height[c] = matrix[r][c] == 1 ? height[c] + 1 : 0;
                Array.Copy(height, _height, ccnt);
                Array.Sort(_height, comparer);
                for (int c = 0; c < ccnt; c++) result = Math.Max(result, (c + 1) * _height[c]);
            }

            return result;
        }
    }
}
