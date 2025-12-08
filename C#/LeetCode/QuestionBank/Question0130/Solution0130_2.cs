using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0130
{
    public class Solution0130_2 : Interface0130
    {
        /// <summary>
        /// BFS
        /// 逻辑与Solution0130完全一样，只是将DFS改为BFS
        /// </summary>
        /// <param name="board"></param>
        public void Solve(char[][] board)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int c = 0; c < ccnt; c++)
            {
                if (board[0][c] == 'O') queue.Enqueue((0, c));
                if (board[rcnt - 1][c] == 'O') queue.Enqueue((rcnt - 1, c));
            }
            for (int r = 1; r < rcnt - 1; r++)
            {
                if (board[r][0] == 'O') queue.Enqueue((r, 0));
                if (board[r][ccnt - 1] == 'O') queue.Enqueue((r, ccnt - 1));
            }

            (int r, int c) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (board[item.r][item.c] != 'O') continue;
                board[item.r][item.c] = 'F';
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = item.r + dirs[i]; _c = item.c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) queue.Enqueue((_r, _c));
                }
            }

            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (board[r][c] != 'X') board[r][c] = (char)(board[r][c] + 9);
                }
        }
    }
}
