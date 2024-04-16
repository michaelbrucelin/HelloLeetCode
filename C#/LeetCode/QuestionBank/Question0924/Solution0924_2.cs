using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0924
{
    public class Solution0924_2 : Interface0924
    {
        /// <summary>
        /// BFS
        /// 逻辑同Solution0924，只是将DFS查找连通分量改为了BFS
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
            Queue<int> queue = new Queue<int>();
            for (int i = 0, _i; i < n; i++) if (!visited[i])
                {
                    sets.Add(new HashSet<int>()); queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        if (visited[_i = queue.Dequeue()]) continue;
                        sets[^1].Add(_i); visited[_i] = true;
                        for (int j = 0; j < n; j++) if (graph[_i][j] == 1) queue.Enqueue(j);
                    }
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
    }
}
