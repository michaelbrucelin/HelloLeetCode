using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0037
{
    public class Solution0037_3 : Interface0037
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku(char[][] board)
        {
            int[,] mask = new int[3, 9];
            for (int r = 0; r < 9; r++) for (int c = 0; c < 9; c++) if (board[r][c] != '.') enmask(r, c, board[r][c] & 15);
            backtrack(0, 0);
            return;

            bool backtrack(int r, int c)
            {
                if (r == 9) return true;
                int _r, _c;
                if (c == 8) { _r = r + 1; _c = 0; } else { _r = r; _c = c + 1; }
                if (board[r][c] != '.')
                {
                    return backtrack(_r, _c);
                }
                else
                {
                    for (int v = 1; v < 10; v++) if (check(r, c, v))
                        {
                            board[r][c] = (char)(v | 48);
                            enmask(r, c, v);
                            if (backtrack(_r, _c)) goto FOUND; else { unmask(r, c, v); }
                        }
                    board[r][c] = '.';
                }
                return false;
            FOUND:;
                return true;
            }

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

            void unmask(int r, int c, int v)
            {
                v = 1 << v;
                int p = r / 3 * 3 + c / 3;
                mask[0, r] ^= v;
                mask[1, c] ^= v;
                mask[2, p] ^= v;
            }
        }
    }
}
