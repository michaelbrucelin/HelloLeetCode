using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0741
{
    public class Solution0741 : Interface0741
    {
        /// <summary>
        /// DFS
        /// 1. 回程可以理解为另一条去程路线
        /// 2. DFS可以可以找出所有去程路线，并记录在哪些位置摘到了樱桃
        /// 3. 所有去程两两组合并计算摘樱桃位置的并集，即是结果
        /// 4. 记录摘樱桃的位置可以使用集合，也可以使用int[]，这里先使用集合
        /// 
        /// 肉眼可见的会TLE及OLE，先写出来试试，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CherryPickup(int[][] grid)
        {
            int n = grid.Length;
            List<HashSet<int>> masks = new List<HashSet<int>>();
            dfs(grid, n, 0, 0, new HashSet<int>(), masks);

            if (masks.Count == 0) return 0;
            if (masks.Count == 1) return masks[0].Count;
            int result = 0;
            for (int i = 0; i < masks.Count; i++) for (int j = i + 1; j < masks.Count; j++)
                {
                    result = Math.Max(result, masks[i].Union(masks[j]).Count());
                }
            return result;
        }

        private void dfs(int[][] grid, int n, int r, int c, HashSet<int> mask, List<HashSet<int>> masks)
        {
            if (grid[r][c] == 1) mask.Add(r * n + c);
            if (r == n - 1 && c == n - 1) { masks.Add(mask); return; }
            if (r < n - 1 && grid[r + 1][c] != -1) dfs(grid, n, r + 1, c, new HashSet<int>(mask), masks);
            if (c < n - 1 && grid[r][c + 1] != -1) dfs(grid, n, r, c + 1, new HashSet<int>(mask), masks);
        }
    }
}
