using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1886
{
    public class Solution1886_3 : Interface1886
    {
        /// <summary>
        /// 原地比较
        /// 所谓旋转后比较，无非就是原地换个顺序比较
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindRotation(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    if (mat[r][c] != target[r][c]) goto One;
            return true;

            One:
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    if (mat[n - c - 1][r] != target[r][c]) goto Two;
            return true;

            Two:
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    if (mat[n - r - 1][n - c - 1] != target[r][c]) goto Three;
            return true;

            Three:
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    if (mat[c][n - r - 1] != target[r][c]) goto End;
            return true;

            End:
            return false;
        }

        /// <summary>
        /// 与FindRotation()，使用编码技巧优化代码
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindRotation2(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            var map = new Func<(int r, int c), (int r, int c)>[] {
                t => (t.r, t.c), t => (n - t.c - 1, t.r), t => (n - t.r - 1, n - t.c - 1), t => (t.c, n - t.r - 1)
            };

            (int r, int c) pos;
            for (int t = 0; t < 4; t++)
            {
                for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    {
                        pos = map[t]((r, c));
                        if (mat[pos.r][pos.c] != target[r][c]) goto False;
                    }
                return true;
                False:;
            }

            return false;
        }
    }
}
