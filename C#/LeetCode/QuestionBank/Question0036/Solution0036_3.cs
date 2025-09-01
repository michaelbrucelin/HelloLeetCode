using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0036
{
    public class Solution0036_3 : Interface0036
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            int[,] mask = new int[3, 9];
            for (int r = 0; r < 9; r++) for (int c = 0; c < 9; c++) if (board[r][c] != '.')
                    {
                        if (!check(r, c, board[r][c] & 15)) return false; else enmask(r, c, board[r][c] & 15);
                    }
            return true;

            bool check(int r, int c, int v)
            {
                int p = r / 3 * 3 + c / 3;
                if (((mask[0, r] >> v) & 1) != 0 || ((mask[1, c] >> v) & 1) != 0 || ((mask[2, p] >> v) & 1) != 0) return false;
                return true;
            }

            void enmask(int r, int c, int v)
            {
                v = 1 << v;
                int p = r / 3 * 3 + c / 3;
                mask[0, r] |= v;
                mask[1, c] |= v;
                mask[2, p] |= v;
            }
        }
    }
}
