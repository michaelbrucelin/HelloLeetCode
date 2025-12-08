using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0130
{
    public class Solution0130 : Interface0130
    {
        /// <summary>
        /// DFS
        /// 1. 从所有边缘的O为起点DFS，将O改为o
        /// 2. 将所有O改为X，将o改为O
        /// </summary>
        /// <param name="board"></param>
        public void Solve(char[][] board)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            for (int c = 0; c < ccnt; c++) { dfs(0, c); dfs(rcnt - 1, c); }
            for (int r = 1; r < rcnt - 1; r++) { dfs(r, 0); dfs(r, ccnt - 1); }
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (board[r][c] == 'O') board[r][c] = 'X'; else if (board[r][c] == 'o') board[r][c] = 'O';
                }

            void dfs(int r, int c)
            {
                if (board[r][c] != 'O') return;
                board[r][c] = 'o';
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) dfs(_r, _c);
                }
            }
        }

        /// <summary>
        /// 逻辑完全同Solve()，使用小技巧稍微优化
        /// </summary>
        /// <param name="board"></param>
        public void Solve2(char[][] board)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            for (int c = 0; c < ccnt; c++) { dfs(0, c); dfs(rcnt - 1, c); }
            for (int r = 1; r < rcnt - 1; r++) { dfs(r, 0); dfs(r, ccnt - 1); }
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (board[r][c] != 'X') board[r][c] = (char)(board[r][c] + 9);
                }

            void dfs(int r, int c)
            {
                if (board[r][c] != 'O') return;
                board[r][c] = 'F';
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) dfs(_r, _c);
                }
            }
        }
    }
}
