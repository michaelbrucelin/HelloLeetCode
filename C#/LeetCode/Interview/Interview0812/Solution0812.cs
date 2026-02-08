using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0812
{
    public class Solution0812 : Interface0812
    {
        /// <summary>
        /// 回溯
        /// 用4个bool数组表示 行 列 斜线 反斜线 方向有没有棋子，行不需要
        /// 对角线的坐标 r+c 是固定值，[0 - 2n-1]，反对角线的坐标 r-c+n-1 是固定值，[0 - 2n-1]
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> result = [];
            bool[] mask_c = new bool[n], mask_rc = new bool[(n << 1) - 1], mask_cr = new bool[(n << 1) - 1];
            char[][] buffer = new char[n][];
            for (int r = 0; r < n; r++)
            {
                buffer[r] = new char[n];
                for (int c = 0; c < n; c++) buffer[r][c] = '.';
            }
            backtrack(0);

            return result;

            void backtrack(int r)
            {
                if (r == n)
                {
                    string[] solution = new string[n];
                    for (int i = 0; i < n; i++) solution[i] = new string(buffer[i]);
                    result.Add(solution);
                    return;
                }

                for (int c = 0; c < n; c++) if (!mask_c[c] && !mask_rc[r + c] && !mask_cr[r - c + n - 1])
                    {
                        buffer[r][c] = 'Q';
                        mask_c[c] = true; mask_rc[r + c] = true; mask_cr[r - c + n - 1] = true;
                        backtrack(r + 1);
                        buffer[r][c] = '.';
                        mask_c[c] = false; mask_rc[r + c] = false; mask_cr[r - c + n - 1] = false;
                    }
            }
        }
    }
}
