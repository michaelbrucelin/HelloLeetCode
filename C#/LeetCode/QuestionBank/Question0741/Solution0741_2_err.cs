using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using intx = System.UInt64;  // System.UInt64, System.UInt128

namespace LeetCode.QuestionBank.Question0741
{
    public class Solution0741_2_err : Interface0741
    {
        private const int intl = 64;  // 64, 128

        public int CherryPickup(int[][] grid)
        {
            int n = grid.Length;
            int m = (int)Math.Ceiling(n * n / (double)intl);
            List<intx[]> masks = new List<intx[]>();
            dfs(grid, n, 0, 0, new intx[m], masks);

            if (masks.Count == 0) return 0;
            int result = 0;
            if (masks.Count == 1)
            {
                foreach (intx i in masks[0]) result += BitCount(i);
            }
            else
            {
                int _result;
                for (int i = 0; i < masks.Count; i++) for (int j = i + 1; j < masks.Count; j++)
                    {
                        _result = 0;
                        for (int k = 0; k < m; k++) _result += BitCount(masks[i][k] | masks[j][k]);
                        result = Math.Max(result, _result);
                    }
            }
            return result;
        }

        private void dfs(int[][] grid, int n, int r, int c, intx[] mask, List<intx[]> masks)
        {
            if (grid[r][c] == 1) mask[(r * n + c) / intl] |= 1U << ((r * n + c) % intl);
            if (r == n - 1 && c == n - 1) { masks.Add(mask); return; }
            if (r < n - 1 && grid[r + 1][c] != -1) dfs(grid, n, r + 1, c, mask.ToArray(), masks);
            if (c < n - 1 && grid[r][c + 1] != -1) dfs(grid, n, r, c + 1, mask.ToArray(), masks);
        }

        private int BitCount(intx num)
        {
            int result = 0;
            while (num > 0) { result++; num &= num - 1; }

            return result;
        }
    }
}
