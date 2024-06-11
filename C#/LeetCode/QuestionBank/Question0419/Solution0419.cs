using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0419
{
    public class Solution0419 : Interface0419
    {
        private readonly static int[] dirs = [-1, 0, 1, 0, -1];

        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int CountBattleships(char[][] board)
        {
            int result = 0, rcnt = board.Length, ccnt = board[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (board[r][c] != '.')
                    {
                        result++; ClearBattleships(board, r, c);
                    }

            return result;
        }

        private void ClearBattleships(char[][] board, int r, int c)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((r, c));
            (int r, int c) item; int _r, _c;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                board[item.r][item.c] = '.';
                for (int i = 0; i < 4; i++)
                {
                    _r = item.r + dirs[i]; _c = item.c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt)
                    {
                        if (board[_r][_c] != '.') queue.Enqueue((_r, _c));
                    }
                }
            }
        }
    }
}
