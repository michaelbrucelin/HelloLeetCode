using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1377
{
    public class Solution1377 : Interface1377
    {
        /// <summary>
        /// BFS
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
            if (target == 1)
            {
                if (t == 0 || !arc.ContainsKey(1)) return 1; else return 0;
            }

            double[] prs = new double[n + 1]; prs[1] = 1;
            Queue<int> queue = new Queue<int>(); queue.Enqueue(1);
            int cnt; while (t-- > 0 && (cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int vex = queue.Dequeue();
                    if (arc.ContainsKey(vex))
                    {
                        foreach (int _vex in arc[vex]) arc[_vex].Remove(vex);
                        if (arc[vex].Contains(target))
                        {
                            if (t == 0 || arc[target].Count == 0)
                                return prs[vex] / arc[vex].Count;
                            else
                                return 0;
                        }
                        else
                        {
                            foreach (int _vex in arc[vex])
                            {
                                prs[_vex] = prs[vex] / arc[vex].Count;
                                queue.Enqueue(_vex);
                            }
                        }
                    }
                }
            }

            return prs[target];
        }
    }
}
