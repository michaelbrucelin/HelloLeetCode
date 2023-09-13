using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2596
{
    public class Solution2596 : Interface2596
    {
        private static readonly (int x, int y)[] dirs = new (int x, int y)[] { (-2, 1), (-2, -1), (-1, 2), (-1, -2), (1, 2), (1, -2), (2, 1), (2, -1) };

        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool CheckValidGrid(int[][] grid)
        {
            if (grid[0][0] != 0) return false;

            int px = 0, py = 0, _px, _py, step = 0, len = grid.Length;
            while (true)
            {
                step++;
                foreach (var dir in dirs)
                {
                    _px = px + dir.x; _py = py + dir.y;
                    if (_px >= 0 && _px < len && _py >= 0 && _py < len && grid[_px][_py] == step)
                    {
                        px = _px; py = _py; goto Continue;
                    }
                }
                break;
                Continue:;
            }

            return step == len * len;
        }
    }
}
