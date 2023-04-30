using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1275
{
    public class Solution1275 : Interface1275
    {
        /// <summary>
        /// 由题目知，如果由胜利方，那么最后一步棋是胜利方掷出的，而且这步棋一定是制胜棋，即在直线上
        /// 所以直接检查最后一步棋即可
        /// 无论最后一步棋摆在哪里，都需要检查所在行，所在列，如果最后一步棋的横纵坐标和是偶数，还要检查对角线
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public string Tictactoe(int[][] moves)
        {
            int[,] board = new int[3, 3];  // 1: A, 2: B
            int len = moves.Length;
            for (int i = 0; i < len; i++) board[moves[i][0], moves[i][1]] = (i & 1) + 1;

            int row = moves[len - 1][0], col = moves[len - 1][1];
            int win = board[row, col];
            if ((board[row, 0] == win && board[row, 1] == win && board[row, 2] == win) ||
                (board[0, col] == win && board[1, col] == win && board[2, col] == win))
                return ((char)('A' + win - 1)).ToString();
            if (((row + col) & 1) != 1)
            {
                switch ((row, col))
                {
                    case (0, 0):
                    case (2, 2):
                        if (board[0, 0] == win && board[1, 1] == win && board[2, 2] == win)
                            return ((char)('A' + win - 1)).ToString();
                        break;
                    case (0, 2):
                    case (2, 0):
                        if (board[0, 2] == win && board[1, 1] == win && board[2, 0] == win)
                            return ((char)('A' + win - 1)).ToString();
                        break;
                    case (1, 1):
                        if ((board[0, 0] == win && board[1, 1] == win && board[2, 2] == win) ||
                            (board[0, 2] == win && board[1, 1] == win && board[2, 0] == win))
                            return ((char)('A' + win - 1)).ToString();
                        break;
                }
            }

            return len < 9 ? "Pending" : "Draw";
        }
    }
}
