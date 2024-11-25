using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1275
{
    public class Solution1275_2 : Interface1275
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public string Tictactoe(int[][] moves)
        {
            char[,] board = new char[3, 3];
            for (int i = 0; i < moves.Length; i += 2) board[moves[i][0], moves[i][1]] = 'A';
            for (int i = 1; i < moves.Length; i += 2) board[moves[i][0], moves[i][1]] = 'B';

            for (int i = 0; i < 3; i++) if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    if (board[i, 0] == 'A') return "A";
                    if (board[i, 0] == 'B') return "B";
                }
            for (int i = 0; i < 3; i++) if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    if (board[0, i] == 'A') return "A";
                    if (board[0, i] == 'B') return "B";
                }
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                if (board[0, 0] == 'A') return "A";
                if (board[0, 0] == 'B') return "B";
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                if (board[0, 2] == 'A') return "A";
                if (board[0, 2] == 'B') return "B";
            }

            return moves.Length == 9 ? "Draw" : "Pending";
        }
    }
}
