using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0037
{
    public class Solution0037_2 : Interface0037
    {
        /// <summary>
        /// 回溯
        /// 逻辑同Solution0037，只是Solution0037中的IsValidSudoku()是从Question0036中copy的，验证的是整个棋盘
        /// 而这里其实只需要验证单元格的所在行，所在列以及所在块即可
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {
            SolveSudoku(board, 0);
        }

        private bool SolveSudoku(char[][] board, int k)
        {
            if (k > 80) return true;

            int r = k / 9, c = k % 9;
            if (board[r][c] != '.') return SolveSudoku(board, k + 1);

            for (char i = '1'; i <= '9'; i++)
            {
                board[r][c] = i;
                if (IsValidSudoku(board, r, c))
                {
                    if (SolveSudoku(board, k + 1)) return true;
                }
            }

            board[r][c] = '.';
            return false;
        }

        private bool IsValidSudoku(char[][] board, int r, int c)
        {
            int val, mask;
            // 行
            mask = 0;
            for (int _c = 0; _c < 9; _c++) if (!check(r, _c)) return false;
            // 列
            mask = 0;
            for (int _r = 0; _r < 9; _r++) if (!check(_r, c)) return false;
            // 块
            mask = 0; r = r / 3 * 3; c = c / 3 * 3;
            for (int _r = 0; _r < 3; _r++) for (int _c = 0; _c < 3; _c++) if (!check(r + _r, c + _c)) return false;

            return true;

            bool check(int r, int c)
            {
                if (board[r][c] != '.')
                {
                    val = board[r][c] & 15;
                    if (((mask >> val) & 1) != 0) return false; else mask |= 1 << val;
                }
                return true;
            }
        }
    }
}
