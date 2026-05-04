using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0529
{
    public class Solution0529 : Interface0529
    {
        /// <summary>
        /// 递归模拟
        /// </summary>
        /// <param name="board"></param>
        /// <param name="click"></param>
        /// <returns></returns>
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            rec(click[0], click[1]);
            return board;

            void rec(int r, int c)
            {
                visited[r, c] = true;
                switch (board[r][c])
                {
                    case 'M': board[r][c] = 'X'; goto END;
                    case 'E':
                        int cnt = 0;
                        for (int ri = -1, _r, _c; ri < 2; ri++) for (int ci = -1; ci < 2; ci++)
                            {
                                _r = r + ri; _c = c + ci;
                                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt)
                                {
                                    if (board[_r][_c] == 'M' || board[_r][_c] == 'X') cnt++;
                                }
                            }
                        board[r][c] = (char)(cnt + '0');
                        if (cnt == 0) board[r][c] = 'B'; else goto END;
                        break;
                    case 'B': break;
                    case 'X': goto END;
                    default: goto END;   // 1-8
                }

                for (int ri = -1, _r, _c; ri < 2; ri++) for (int ci = -1; ci < 2; ci++)
                    {
                        _r = r + ri; _c = c + ci;
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && (_r != r || _c != c))
                        {
                            if (!visited[_r, _c]) rec(_r, _c);
                        }
                    }

                END:;
            }
        }
    }
}
