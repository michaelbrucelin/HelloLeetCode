using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1222
{
    public class Solution1222 : Interface1222
    {
        private static readonly (int x, int y)[] dirs = new (int x, int y)[] { (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0) };

        /// <summary>
        /// 模拟，类BFS
        /// 先绘制棋盘，然后8个方向分别找第一个就可以
        /// </summary>
        /// <param name="queens"></param>
        /// <param name="king"></param>
        /// <returns></returns>
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            int[,] board = new int[8, 8];
            foreach (var arr in queens) board[arr[0], arr[1]] = 1;

            IList<IList<int>> result = new List<IList<int>>();
            int x, y, _x, _y;
            foreach (var dir in dirs)
            {
                x = king[0]; y = king[1];
                for (int i = 1; ; i++)
                {
                    _x = x + dir.x; _y = y + dir.y;
                    if (_x < 0 || _x > 7 || _y < 0 || _y > 7) break;
                    if (board[_x, _y] == 1)
                    {
                        result.Add(new int[] { _x, _y }); break;
                    }
                    else
                    {
                        x = _x; y = _y;
                    }
                }
            }

            return result;
        }
    }
}
