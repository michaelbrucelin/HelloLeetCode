using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2920
{
    public class Solution2920_4 : Interface2920
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution2920_3，将DFS改为DP
        /// 1. 自底向上逐层遍历
        /// 2. dp[i,j]表示以节点i为根的子树，节点i的祖先（不含节点i）一共折半j次的结果
        /// 3. dp[i,j] = Max(coins[i] >> j - k + Max(dp[_i,j]),     节点i不折半  dp[_i,] 是 dp[i,] 的所有子节点
        ///                  coins[i] >> (j+1) + Max(dp[_i,(j+1)])  节点i折半    dp[_i,] 是 dp[i,] 的所有子节点
        /// 
        /// 逻辑完全同Solution2920_3，只是将DFS改为了DP，速度提高了10倍。。。不确认真的 迭代+数组 比 递归+字典 真的快乐这么多，还是LeetCode的统计不准确
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="coins"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumPoints(int[][] edges, int[] coins, int k)
        {
            if (k == 0) return coins.Sum();

            // 创建有向树
            int n = coins.Length;
            HashSet<int>[] tree = new HashSet<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new HashSet<int>();
            foreach (int[] edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }
            for (int i = 0; i < n; i++) foreach (int j in tree[i]) tree[j].Remove(i);

            // 计算树每层的节点
            List<List<int>> level = new List<List<int>>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int cnt, node; while ((cnt = queue.Count) > 0)
            {
                level.Add(new List<int>());
                for (int i = 0; i < cnt; i++)
                {
                    node = queue.Dequeue();
                    level[^1].Add(node);
                    foreach (int _node in tree[node]) queue.Enqueue(_node);
                }
            }

            int[,] dp = new int[n, 15];
            foreach (int _node in level[^1]) for (int j = Math.Min(level.Count, 13), point; j >= 0; j--)                                      // 最后一层
                {
                    point = coins[_node] >> j;
                    dp[_node, j] = Math.Max(point - k, point >> 1);
                }
            for (int i = level.Count - 2; i >= 0; i--) foreach (int _node in level[i]) for (int j = Math.Min(i + 1, 13), point; j >= 0; j--)  // 自底向上，逐层dp
                    {
                        point = coins[_node] >> j;
                        int r1 = point - k, r2 = point >> 1;
                        foreach (int next in tree[_node]) { r1 += dp[next, j]; r2 += dp[next, j + 1]; }
                        dp[_node, j] = Math.Max(r1, r2);
                    }

            return dp[0, 0];
        }
    }
}
