using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1886
{
    public class Solution1886_2 : Interface1886
    {
        /// <summary>
        /// 模拟
        /// 与Solution1886一样，只是旋转数组改为原地旋转，对于这道题没有实际意义（可以直接Solution1886_3），这里只是写着玩的
        /// 原地旋转，每个位置(r,c)都由(n-c-1,r)位置的值替换
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindRotation(int[][] mat, int[][] target)
        {
            if (Compare(mat, target)) return true;
            for (int i = 0; i < 3; i++)
            {
                Rotation(mat);
                if (Compare(mat, target)) return true;
            }

            return false;
        }

        private void Rotation(int[][] mat)
        {
            int n = mat.Length, m = (mat.Length - 1) >> 1;
            for (int r = 0; r <= m; r++) for (int c = r; c <= n - r - 2; c++)
                {
                    int t = mat[r][c], _r = r, _c = c;
                    for (int k = 0; k < 3; k++)
                    {
                        mat[_r][_c] = mat[n - _c - 1][_r];
                        int _t = _r; _r = n - _c - 1; _c = _t;
                    }
                    mat[_r][_c] = t;
                }
        }

        private bool Compare(int[][] arr1, int[][] arr2)
        {
            int n = arr1.Length;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    if (arr1[r][c] != arr2[r][c]) return false;

            return true;
        }
    }
}
