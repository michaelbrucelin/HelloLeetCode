using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1886
{
    public class Solution1886_4 : Interface1886
    {
        /// <summary>
        /// 模拟
        /// 原坐标      旋转1次      旋转2次      旋转3次      旋转4次
        /// (r,c)       (c,n-r-1)    (n-r-1,n-c-1)(n-c-1,r)    (r,c)
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindRotation(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            if (n == 1) return mat[0][0] == target[0][0];

            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) if (mat[r][c] != target[r][c]) goto CONTINUE0;
            return true;
        CONTINUE0:;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) if (mat[r][c] != target[c][n - r - 1]) goto CONTINUE1;
            return true;
        CONTINUE1:;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) if (mat[r][c] != target[n - r - 1][n - c - 1]) goto CONTINUE2;
            return true;
        CONTINUE2:;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) if (mat[r][c] != target[n - c - 1][r]) goto CONTINUE3;
            return true;
        CONTINUE3:;

            return false;
        }
    }
}
