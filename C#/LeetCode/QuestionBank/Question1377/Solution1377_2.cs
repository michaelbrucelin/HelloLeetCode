using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1377
{
    public class Solution1377_2 : Interface1377
    {
        /// <summary>
        /// DFS
        /// 1. 由于是树，所以任意两个顶点有且仅有一条路径
        ///     如果起点或终点是树的根，结论显然
        ///     如果起点与终点都不是树的根，那么 起点—根—终点 就是唯一的路径
        /// 2. 结论1非常重要，因为这样无论BFS还是DFS，都无需为每种选择单独建立“状态变量”，例如visited数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="t"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public double FrogPosition(int n, int[][] edges, int t, int target)
        {
            Dictionary<int, HashSet<int>> arc = new Dictionary<int, HashSet<int>>();  // 将edges转为更方便的数据结构
            foreach (var edge in edges)
            {
                if (arc.ContainsKey(edge[0])) arc[edge[0]].Add(edge[1]); else arc.Add(edge[0], new HashSet<int>() { edge[1] });
                if (arc.ContainsKey(edge[1])) arc[edge[1]].Add(edge[0]); else arc.Add(edge[1], new HashSet<int>() { edge[0] });
            }
            double[] prs = new double[n + 1]; prs[1] = 1;
            double result = dfs(arc, prs, 1, t, target);

            return result != -1 ? result : 0;
        }

        private double dfs(Dictionary<int, HashSet<int>> arc, double[] prs, int start, int t, int target)
        {
            if (start == target)
            {
                if (t == 0 || !arc.ContainsKey(target) || arc[target].Count == 0) return prs[target]; else return 0;
            }
            if (t == 0) return -1;  // 表示没有到达目标

            if (arc.ContainsKey(start))
            {
                foreach (int vex in arc[start])
                {
                    arc[vex].Remove(start);
                    prs[vex] = prs[start] / arc[start].Count;
                    double result = dfs(arc, prs, vex, t - 1, target);
                    if (result != -1) return result;
                }
            }

            return -1;
        }
    }
}
