using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0289
{
    public class Solution0289_2 : Interface0289
    {
        /// <summary>
        /// 原地模拟
        /// </summary>
        /// <param name="board"></param>
        public void GameOfLife(int[][] board)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            for (int r = 0, _r, _c, cnt; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    cnt = -board[r][c];
                    for (int i = -1; i < 2; i++) for (int j = -1; j < 2; j++)
                        {
                            _r = r + i; _c = c + j;
                            if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) cnt += board[_r][_c] & 1;
                        }

                    if (board[r][c] == 1)
                    {
                        if (cnt == 2 || cnt == 3) board[r][c] |= 2;
                    }
                    else
                    {
                        if (cnt == 3) board[r][c] |= 2;
                    }
                }

            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) board[r][c] >>= 1;
            return;
        }
    }
}
