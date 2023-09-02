using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0566
{
    public class Solution0566 : Interface0566
    {
        /// <summary>
        /// 坐标映射
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if (r * c != rcnt * ccnt || (r == rcnt && c == ccnt)) return mat;

            int[][] result = new int[r][];
            for (int _r = 0; _r < r; _r++) result[_r] = new int[c];
            int id;
            for (int _r = 0; _r < rcnt; _r++) for (int _c = 0; _c < ccnt; _c++)
                {
                    id = _r * ccnt + _c; result[id / c][id % c] = mat[_r][_c];
                }

            return result;
        }

        /// <summary>
        /// 坐标映射
        /// 不计算坐标位置，而是使用比较原始的类似于指针或者游标，每次向前移动一个位置的方式去实现
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[][] MatrixReshape2(int[][] mat, int r, int c)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if (r * c != rcnt * ccnt || (r == rcnt && c == ccnt)) return mat;

            int[][] result = new int[r][];
            for (int _r = 0; _r < r; _r++) result[_r] = new int[c];
            int R = 0, C = 0;
            for (int _r = 0; _r < rcnt; _r++) for (int _c = 0; _c < ccnt; _c++)
                {
                    result[R][C] = mat[_r][_c];
                    if (++C == c) { R++; C = 0; }
                }

            return result;
        }
    }
}
