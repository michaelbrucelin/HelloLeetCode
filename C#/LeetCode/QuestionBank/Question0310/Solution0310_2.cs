using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0310
{
    public class Solution0310_2 : Interface0310
    {
        /// <summary>
        /// DFS + 树的换根
        /// 1. 树换根之后，只有“原根”与“新根”两个节点的高度发生了变化
        /// 2. 原根高度：除了新根以外其它子节点的高度的最大值 + 1
        /// 3. 新根高度：原高度 与 原根新高度+1 二者的最大值，其实所有子节点高度最大值 + 1
        /// 
        /// 逻辑没问题，提交后OLE了，参考测试用例04，想想也是，创建了太多数组了，问题可以通过回溯来解决
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
                    int[] _dp = dp.ToArray();
                    _dp[v] = 1;
                    foreach (int c in tree[v]) if (c != _v) _dp[v] = Math.Max(_dp[v], dp[c] + 1);
                    _dp[_v] = Math.Max(_dp[_v], _dp[v] + 1);
                    dfs(tree, _v, v, _dp, heights, ref minHeight);
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
