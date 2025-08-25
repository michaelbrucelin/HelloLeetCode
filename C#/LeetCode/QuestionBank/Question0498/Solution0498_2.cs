using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0498
{
    public class Solution0498_2 : Interface0498
    {
        /// <summary>
        /// 遍历
        /// 到达边界即需要改变方向，即改变行坐标与列坐标的增量
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindDiagonalOrder(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[] result = new int[rcnt * ccnt];
            int r = 0, c = 0, _r = -1, _c = 1;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = mat[r][c];
                r += _r; c += _c;
                if (r == rcnt) { r -= 1; c += 2; _r = -1; _c = 1; }
                else if (c == ccnt) { r += 2; c -= 1; _r = 1; _c = -1; }
                else if (r == -1) { r = 0; _r = 1; _c = -1; }
                else if (c == -1) { c = 0; _r = -1; _c = 1; }
            }

            return result;
        }
    }
}
