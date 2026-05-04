using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0048
{
    public class Solution0048_4 : Interface0048
    {
        /// <summary>
        /// 模拟
        /// 先看看4*4矩阵坐标的变化规律
        /// 00 -> 03 -> 33 -> 30 -> 00
        /// 01 -> 13 -> 32 -> 20 -> 01
        /// 02 -> 23 -> 31 -> 10 -> 02
        /// 11 -> 12 -> 22 -> 21 -> 11
        /// 拿 00  -> 03 为例，靠内测的值不变，即 0 -> 0，靠外侧的值的和为 n-1，即 0+3=4-1
        /// 所以，(r,c)  -> (c,n-1-r)
        /// 用左上角的元素依次与右上角，右下角，左下角三个位置交换即可
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int r = 0, cl = 0, cr = n - 2; cl <= cr; r++, cl++, cr--) for (int c = cl, _r, _c, t; c <= cr; c++)
                {
                    _r = r; _c = c;
                    for (int i = 0; i < 3; i++)
                    {
                        (_r, _c) = (_c, n - 1 - _r);
                        t = matrix[_r][_c]; matrix[_r][_c] = matrix[r][c]; matrix[r][c] = t;
                    }
                }
        }
    }
}
