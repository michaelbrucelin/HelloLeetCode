using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0741
{
    public class Solution0741_2 : Interface0741
    {
        /// <summary>
        /// DFS
        /// 逻辑同Solution0741，只是将其中的HashSet<int>改为了int[]，测试一下性能，写着玩的
        /// 
        /// 发现了一个问题，测试用例03中
        ///     使用unit[]，  结果是对的，22
        ///     使用ulong[]， 结果是错的，21
        ///     使用uint64[]，结果是错的，17
        /// 不确定是什么原因导致的，可以使用逻辑同Solution0741_2_err进行测试
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CherryPickup(int[][] grid)
        {
            int n = grid.Length;
            int m = (int)Math.Ceiling(n * n / 32D);
            List<uint[]> masks = new List<uint[]>();
            dfs(grid, n, 0, 0, new uint[m], masks);

            if (masks.Count == 0) return 0;
            int result = 0;
            if (masks.Count == 1)
            {
                foreach (uint i in masks[0]) result += BitCount(i);
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

        private void dfs(int[][] grid, int n, int r, int c, uint[] mask, List<uint[]> masks)
        {
            if (grid[r][c] == 1) mask[(r * n + c) / 32] |= 1U << ((r * n + c) % 32);
            if (r == n - 1 && c == n - 1) { masks.Add(mask); return; }
            if (r < n - 1 && grid[r + 1][c] != -1) dfs(grid, n, r + 1, c, mask.ToArray(), masks);
            if (c < n - 1 && grid[r][c + 1] != -1) dfs(grid, n, r, c + 1, mask.ToArray(), masks);
        }

        private int BitCount(uint num)
        {
            int result = 0;
            while (num > 0) { result++; num &= num - 1; }

            return result;
        }
    }
}
