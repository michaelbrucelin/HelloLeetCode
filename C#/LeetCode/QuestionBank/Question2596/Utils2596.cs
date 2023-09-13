using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2596
{
    public class Utils2596
    {
        private static readonly (int x, int y)[] dirs = new (int x, int y)[] { (-2, 1), (-2, -1), (-1, 2), (-1, -2), (1, 2), (1, -2), (2, 1), (2, -1) };

        public void Dial()
        {
            for (int i = 3; i <= 7; i++) FindPath(i);
            Console.WriteLine();
        }

        /// <summary>
        /// 回溯
        /// 寻找答案
        /// </summary>
        /// <param name="n"></param>
        private void FindPath(int n)
        {
            int[,] board = new int[n, n];
            bool found = backtracking(board, n, 0, 0, 0);

            Console.WriteLine($"Found Path: {found}");
            Console.WriteLine("Last Try:");
            Utils.Dump<int>(board, (n * n).ToString().Length, true);
        }

        private bool backtracking(int[,] board, int n, int x, int y, int step)
        {
            if (++step == n * n) return true;

            int _x, _y;
            foreach (var dir in dirs)
            {
                _x = x + dir.x; _y = y + dir.y;
                if (_x >= 0 && _x < n && _y >= 0 && _y < n && board[_x, _y] == 0)
                {
                    board[_x, _y] = step;
                    if (backtracking(board, n, _x, _y, step))
                        return true;
                    else
                        board[_x, _y] = 0;
                }
            }

            return false;
        }
    }
}
