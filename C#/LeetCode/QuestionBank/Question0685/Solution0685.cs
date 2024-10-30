using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0685
{
    public class Solution0685 : Interface0685
    {
        /// <summary>
        /// 分析
        /// 题目的输入是一棵树，然后新增了一条边，所以
        /// 如果新增的边是“顺向”的，即从根指向叶子方向
        ///     则使得某节点，有两个父节点，1 -> 2 -> 4
        ///                                 1 -> 3 -> 4
        ///     删除任何一条边都可以
        /// 如果新增的边是“逆向”的，即从叶子指向根方向
        ///     如果新增的边没有指向根节点，则同时产生了环，且使得某节点具有两个父节点，1 -> 2 -> 3 -> 4 -> 2
        ///     则删除这条边
        ///     如果新增的边直接指向根节点，则只产生了环，1 -> 2 -> 3 -> 4 -> 1
        ///     这时先找到环的全部点，然后环外部的点第一次到达环的点，这个点就是根节点，然后根节点到达其“父”节点的边就是应该删除的边
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            int n = edges.Length;
            int[] tree = new int[n + 1];
            int[] parents = null;         // 多个父节点信息
            Array.Fill(tree, -1);
            foreach (int[] edge in edges)
            {
                if (tree[edge[1]] != -1)  // 找到了多个父节点
                    parents = [edge[1], tree[edge[1]], edge[0]];
                else
                    tree[edge[1]] = edge[0];
            }

            // 寻找环的信息
            HashSet<int> cycle = null;
            if (parents != null)
            {
                for (int i = 1, p; i < 3; i++)
                {
                    cycle = new HashSet<int>() { parents[0] };
                    p = parents[i];
                    while (p != -1 && p != parents[0]) { cycle.Add(p); p = tree[p]; }
                    if (p == -1) cycle = null; else break;
                }
            }
            else
            {
                bool[] mask = new bool[n + 1];
                for (int i = 1, p; i <= n && !mask[i]; i++)
                {
                    p = i; while (p != -1 && !mask[p]) { mask[p] = true; p = tree[p]; }
                    if (p != -1)  // 找到了环
                    {
                        cycle = new HashSet<int>() { p };
                        int next = p;
                        while ((next = tree[next]) != p) cycle.Add(next);
                        break;
                    }
                }
            }

            if (parents != null && cycle != null)
            {
                return cycle.Contains(parents[1]) ? [parents[1], parents[0]] : [parents[2], parents[0]];
            }
            else if (parents != null)  // cycle == null
            {
                for (int i = n - 1; i >= 0; i--)
                    if ((edges[i][0] == parents[1] || edges[i][0] == parents[2]) && edges[i][1] == parents[0]) return edges[i];
                throw new Exception("logic error");
            }
            else // parents == null && cycle != null, 删除环中任意1条边都可以
            {
                for (int i = n - 1; i >= 0; i--)
                    if (cycle.Contains(edges[i][0]) && cycle.Contains(edges[i][1])) return edges[i];
                throw new Exception("logic error");
            }
        }
    }
}
