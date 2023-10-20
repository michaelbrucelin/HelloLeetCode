using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0999
{
    public class Solution0999 : Interface0999
    {
        public int NumRookCaptures(char[][] board)
        {
            int r = -1, c = -1;
            for (int _r = 0; _r < 8; _r++) for (int _c = 0; _c < 8; _c++)
                {
                    if (board[_r][_c] == 'R') (r, c) = (_r, _c);
                }

            int result = 0; int[] dirs = new int[] { -1, 0, 1, 0, -1 };
            for (int i = 0; i < 4; i++)
            {
                for (int _r = r + dirs[i], _c = c + dirs[i + 1]; _r >= 0 && _r < 8 && _c >= 0 && _c < 8; _r += dirs[i], _c += dirs[i + 1])
                {
                    if (board[_r][_c] == 'B') break;
                    if (board[_r][_c] == 'p') { result++; break; }
                }
            }

            return result;
        }
    }
}
