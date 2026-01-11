using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0085
{
    public class Solution0085_2 : Interface0085
    {
        /// <summary>
        /// 递归
        /// 遇到0，就分为4个部分进行递归
        /// 
        /// 逻辑没问题，TLE
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle(char[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            return rec(0, rcnt - 1, 0, ccnt - 1);

            int rec(int top, int bottom, int left, int right)
            {
                int width = right - left + 1, height = bottom - top + 1;
                for (int r = top; r <= bottom; r++) for (int c = left; c <= right; c++)
                    {
                        if (matrix[r][c] == '1') continue;
                        int result = width * (r - top);
                        if (result < (c - left) * height) result = Math.Max(result, rec(top, bottom, left, c - 1));
                        if (result < (right - c) * height) result = Math.Max(result, rec(top, bottom, c + 1, right));
                        if (result < width * (bottom - r)) result = Math.Max(result, rec(r + 1, bottom, left, right));
                        return result;
                    }
                return width * height;
            }
        }
    }
}
