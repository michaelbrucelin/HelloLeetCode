using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0036
{
    public class Solution0036 : Interface0036
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            int mask, val;

            // 行
            for (int r = 0; r < 9; r++)
            {
                mask = 0;
                for (int c = 0; c < 9; c++) if (board[r][c] != '.')
                    {
                        val = board[r][c] & 15;
                        if (((mask >> val) & 1) != 0) return false; else mask |= 1 << val;
                    }
            }

            // 列
            for (int c = 0; c < 9; c++)
            {
                mask = 0;
                for (int r = 0; r < 9; r++) if (board[r][c] != '.')
                    {
                        val = board[r][c] & 15;
                        if (((mask >> val) & 1) != 0) return false; else mask |= 1 << val;
                    }
            }

            // 块
            for (int r = 0; r < 9; r += 3) for (int c = 0; c < 9; c += 3)
                {
                    mask = 0;
                    for (int _r = 0; _r < 3; _r++) for (int _c = 0; _c < 3; _c++) if (board[r + _r][c + _c] != '.')
                            {
                                val = board[r + _r][c + _c] & 15;
                                if (((mask >> val) & 1) != 0) return false; else mask |= 1 << val;
                            }
                }

            return true;
        }

        /// <summary>
        /// 与IsValidSudoku()一样，只是用代码技巧做了简化
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku2(char[][] board)
        {
            int mask, val;

            // 行
            for (int r = 0; r < 9; r++)
            {
                mask = 0;
                for (int c = 0; c < 9; c++) if (!check(r, c)) return false;
            }

            // 列
            for (int c = 0; c < 9; c++)
            {
                mask = 0;
                for (int r = 0; r < 9; r++) if (!check(r, c)) return false;
            }

            // 块
            for (int r = 0; r < 9; r += 3) for (int c = 0; c < 9; c += 3)
                {
                    mask = 0;
                    for (int _r = 0; _r < 3; _r++) for (int _c = 0; _c < 3; _c++) if (!check(r + _r, c + _c)) return false;
                }

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
