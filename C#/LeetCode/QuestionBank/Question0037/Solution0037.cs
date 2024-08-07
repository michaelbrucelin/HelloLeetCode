﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0037
{
    public class Solution0037 : Interface0037
    {
        /// <summary>
        /// 回溯
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
                if (IsValidSudoku(board))
                {
                    if (SolveSudoku(board, k + 1)) return true;
                }
            }

            board[r][c] = '.';
            return false;
        }

        private bool IsValidSudoku(char[][] board)
        {
            int[,] masks = new int[3, 9];  // 1维 行，2维 列， 2维 块
            int val, mask, p;
            for (int r = 0; r < 9; r++) for (int c = 0; c < 9; c++) if (board[r][c] != '.')
                    {
                        val = board[r][c] & 15;
                        mask = 1 << val;
                        if (((masks[0, r] >> val) & 1) != 0) return false; else masks[0, r] |= mask;
                        if (((masks[1, c] >> val) & 1) != 0) return false; else masks[1, c] |= mask;
                        p = r / 3 * 3 + c / 3;
                        if (((masks[2, p] >> val) & 1) != 0) return false; else masks[2, p] |= mask;
                    }

            return true;
        }
    }
}
