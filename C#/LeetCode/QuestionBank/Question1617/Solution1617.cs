using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1617
{
    public class Solution1617 : Interface1617
    {
        private static readonly Dictionary<int, int> pow2 = new Dictionary<int, int>()
        {
            {1,1},{2,2},{4,3},{8,4},{16,5},{32,6},{64,7},{128,8},{256,9},{512,10},{1024,11},{2048,12},{4096,13},{8192,14},{16384,15},{32768,16}
        };

        /// <summary>
        /// 暴力解
        /// 1. 题目中限制顶点数量<=15，那么顶点的组合有32768种可能，可是使用二进制枚举
        /// 2. 每一种组合需要
        ///     1. 验证是不是子树，可以任取一个顶点，BFS，看看是不是可以到达所有的子集中的顶点
        ///     2. 找出子树中的最远距离
        ///         最远距离的两端的顶点，一定是子树的边缘（只有一个相邻顶点）
        ///         遍历子树的每一个边缘顶点，BFS可以找出当前边缘的最远距离，进而找出子树的最远距离
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] CountSubgraphsForEachDiameter(int n, int[][] edges)
        {
            Dictionary<int, HashSet<int>> emap = new Dictionary<int, HashSet<int>>();
            for (int i = 1; i <= n; i++) emap.Add(i, new HashSet<int>());
            for (int i = 0; i < edges.Length; i++)
            {
                emap[edges[i][0]].Add(edges[i][1]); emap[edges[i][1]].Add(edges[i][0]);
            }

            int[] result = new int[n - 1];
            HashSet<int> sub = new HashSet<int>(), _sub = new HashSet<int>(), visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < (2 << n); i++)
            {
                sub.Clear(); _sub.Clear();
                // 获得此次枚举的全部顶点
                int _i = i; while (_i > 0)
                {
                    sub.Add(pow2[_i & (-_i)]); _i &= _i - 1;  // 取最低位的1并移除
                }
                if (sub.Count < 2) continue;

                // 验证是不是连通子图，即题目中的子树
                int anyone = sub.First(), cnt; queue.Enqueue(anyone); visited.Clear();
                while ((cnt = queue.Count) > 0) for (int j = 0; j < cnt; j++)
                    {
                        int _node = queue.Dequeue();
                        //if (sub.Contains(_node) && !visited.Contains(_node))
                        //{
                        _sub.Add(_node);
                        foreach (int __node in emap[_node])
                            if (sub.Contains(__node) && !visited.Contains(__node)) queue.Enqueue(__node);
                        //}
                        visited.Add(_node);
                    }
                if (_sub.Count != sub.Count) continue;

                // 找出连通子图的最远距离
                if (sub.Count < 4) result[sub.Count - 2]++;
                else
                {
                    _sub.Clear();
                    foreach (int node in sub)  // 找出边缘顶点
                    {
                        int ecnt = 0;
                        foreach (int _next in emap[node]) if (sub.Contains(_next)) ecnt++;
                        if (ecnt == 1) _sub.Add(node);
                        //if (emap[node].Count == 1) _sub.Add(node);
                    }
                    int path = 0, _path;
                    foreach (int node in _sub)
                    {
                        _path = -1; queue.Enqueue(node); visited.Clear();
                        while ((cnt = queue.Count) > 0)
                        {
                            _path++;
                            for (int j = 0; j < cnt; j++)
                            {
                                int _node = queue.Dequeue(); visited.Add(_node);
                                foreach (int _next in emap[_node])
                                    if (sub.Contains(_next) && !visited.Contains(_next)) queue.Enqueue(_next);
                            }
                        }
                        path = Math.Max(path, _path);
                    }
                    result[path - 1]++;
                }
            }

            return result;
        }
    }
}
