using LeetCode.QuestionBank.Question0232;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1210
{
    public class Solution1210_2 : Interface1210
    {
        /// <summary>
        /// DFS
        /// 要做好剪枝，否则太慢
        /// 
        /// 提交依然会超时，参考测试用例5
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MinimumMoves(int[][] grid)
        {
            int steps = int.MaxValue, len = grid.Length;   // 题目：2 <= n <= 100，有结果的话结果一定小于200
            Position start = new Position((0, 0), true);
            Dictionary<Position, int> visited = new Dictionary<Position, int>() { { start, 0 } };
            dfs(start, 0, grid, len, visited, ref steps);

            return steps == int.MaxValue ? -1 : steps;
        }

        private void dfs(Position position, int _step, int[][] grid, int len, Dictionary<Position, int> visited, ref int steps)
        {
            if (_step >= steps) return;
            int row = position.point.row, col = position.point.col;
            _step++;
            if (position.direction)
            {
                if (row == len - 1 && col == len - 2) { steps = _step - 1; return; }
                if (col + 2 < len && grid[row][col + 2] != 1)
                {
                    dfs_next(new Position((row, col + 1), true), _step, grid, len, visited, ref steps);
                }
                if (row + 1 < len && grid[row + 1][col] != 1 && grid[row + 1][col + 1] != 1)
                {
                    dfs_next(new Position((row + 1, col), true), _step, grid, len, visited, ref steps);
                    dfs_next(new Position((row, col), false), _step, grid, len, visited, ref steps);
                }
            }
            else
            {
                if (row + 2 < len && grid[row + 2][col] != 1)
                {
                    dfs_next(new Position((row + 1, col), false), _step, grid, len, visited, ref steps);
                }
                if (col + 1 < len && grid[row][col + 1] != 1 && grid[row + 1][col + 1] != 1)
                {
                    dfs_next(new Position((row, col + 1), false), _step, grid, len, visited, ref steps);
                    dfs_next(new Position((row, col), true), _step, grid, len, visited, ref steps);
                }
            }
        }

        private void dfs_next(Position position, int _step, int[][] grid, int len, Dictionary<Position, int> visited, ref int steps)
        {
            if (!visited.ContainsKey(position))
            {
                visited.Add(position, _step); dfs(position, _step, grid, len, visited, ref steps);
            }
            else if (_step < visited[position])
            {
                visited[position] = _step; dfs(position, _step, grid, len, visited, ref steps);
            }
        }

        private struct Position
        {
            public Position((int row, int col) point, bool direction)
            {
                this.point = point;
                this.direction = direction;
            }

            /// <summary>
            /// 蛇尾巴的坐标
            /// </summary>
            public (int row, int col) point;

            /// <summary>
            /// 方向：true: 横; false: 竖;
            /// </summary>
            public bool direction;
        }
    }
}
