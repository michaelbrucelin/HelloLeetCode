using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1958
{
    public class Solution1958 : Interface1958
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rMove"></param>
        /// <param name="cMove"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool CheckMove(char[][] board, int rMove, int cMove, char color)
        {
            int rcnt = board.Length, ccnt = board[0].Length;
            int r, c, k;
            for (int _r = -1; _r < 2; _r++) for (int _c = -1; _c < 2; _c++) if (_r != 0 || _c != 0)
                    {
                        k = 1;
                        r = rMove + k * _r; c = cMove + k * _c;
                        // if (r < 0 || r >= rcnt || c < 0 || c >= ccnt||) continue;
                    }

            return false;
        }
    }
}
