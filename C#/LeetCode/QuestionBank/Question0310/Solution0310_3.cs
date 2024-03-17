using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0310
{
    public class Solution0310_3 : Interface0310
    {
        /// <summary>
        /// 逻辑同Solution0310_2，只是将dfs改为了回溯，来优化空间复杂度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new List<int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            int[] dp = new int[n];  // 初始化为根为0时各个节点的高度
            InitHeight(tree, 0, -1, dp);

            int[] heights = new int[n];
            int minHeight = n;
            dfs(tree, 0, -1, dp, heights, ref minHeight);

            List<int> result = new List<int>();
            for (int i = 0; i < n; i++) if (heights[i] == minHeight) result.Add(i);
            return result;
        }

        private void dfs(List<int>[] tree, int v, int parent, int[] dp, int[] heights, ref int minHeight)
        {
            heights[v] = dp[v];
            minHeight = Math.Min(minHeight, heights[v]);

            // 换根
            foreach (int _v in tree[v]) if (_v != parent)
                {
                    int vh = dp[v], _vh = dp[_v];
                    dp[v] = 1;
                    foreach (int c in tree[v]) if (c != _v) dp[v] = Math.Max(dp[v], dp[c] + 1);
                    dp[_v] = Math.Max(dp[_v], dp[v] + 1);
                    dfs(tree, _v, v, dp, heights, ref minHeight);

                    dp[v] = vh; dp[_v] = _vh;
                }
        }

        private void InitHeight(List<int>[] tree, int v, int parent, int[] dp)
        {
            int height = 1;
            foreach (int _v in tree[v]) if (_v != parent)
                {
                    InitHeight(tree, _v, v, dp);
                    height = Math.Max(height, dp[_v] + 1);
                }
            dp[v] = height;
        }
    }
}
