using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LeetCode.QuestionBank.Question0924
{
    public class Solution0924 : Interface0924
    {
        /// <summary>
        /// DFS
        /// 1. DFS将grpah分为若干个连通分量
        /// 2. 如果一个连通分量中只有一个病毒，那么移除这个病毒就拯救了整个连通分量
        ///    如果一个连通分量中不止一个病毒，那么移除哪个病毒都没有意义
        /// 3. 找含有一个病毒的且节点数最多的连通分量，那个对应的病毒就是结果
        ///    如果不存在只有一个病毒的连通分量，那么移除哪个病毒都没有意义，直接返回最小id的病毒即可
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="initial"></param>
        /// <returns></returns>
        public int MinMalwareSpread(int[][] graph, int[] initial)
        {
            if (initial.Length == 1) return initial[0];

            int n = graph.Length;
            List<HashSet<int>> sets = new List<HashSet<int>>();
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++) if (!visited[i])
                {
                    sets.Add(new HashSet<int>());
                    dfs(graph, n, i, sets, visited);
                }

            int result = initial.Min(), cnt = 0, _cnt, _id = int.MaxValue;
            HashSet<int> set = new HashSet<int>(initial);
            foreach (var _set in sets)  // _set驱动set O(n)，set驱动_set O(n^2)
            {
                if (_set.Count < cnt) continue;
                _cnt = 0;
                foreach (int i in _set) if (set.Contains(i))
                    {
                        if (++_cnt > 1) break; else _id = i;
                    }
                if (_cnt == 1 && (_set.Count > cnt || _id < result))
                {
                    result = _id; cnt = _set.Count;
                }
            }

            return result;
        }

        private void dfs(int[][] graph, int n, int id, List<HashSet<int>> sets, bool[] visited)
        {
            if (visited[id]) return;

            sets[^1].Add(id); visited[id] = true;
            for (int i = 0; i < n; i++) if (graph[id][i] == 1) dfs(graph, n, i, sets, visited);
        }
    }
}
