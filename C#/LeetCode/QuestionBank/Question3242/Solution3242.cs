using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3242
{
    public class Solution3242
    {
    }

    public class NeighborSum : Interface3242
    {
        public NeighborSum(int[][] grid)
        {
            n = grid.Length;
            this.grid = grid;
            map_r = new int[n * n];
            map_c = new int[n * n];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                {
                    map_r[grid[r][c]] = r; map_c[grid[r][c]] = c;
                }
        }

        private int n;
        private int[][] grid;
        private int[] map_r;
        private int[] map_c;
        private int[] dir_a = [-1, 0, 1, 0, -1];
        private int[] dir_d = [-1, -1, 1, 1, -1];

        public int AdjacentSum(int value)
        {
            return Sum(value, dir_a);
        }

        public int DiagonalSum(int value)
        {
            return Sum(value, dir_d);
        }

        private int Sum(int value, int[] dir)
        {
            int result = 0, r = map_r[value], c = map_c[value], _r, _c;
            for (int i = 0; i < 4; i++)
            {
                _r = r + dir[i]; _c = c + dir[i + 1];
                if (_r >= 0 && _r < n && _c >= 0 && _c < n) result += grid[_r][_c];
            }

            return result;
        }
    }
}
