using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0924
{
    public class Solution0924_3 : Interface0924
    {
        /// <summary>
        /// 并查集
        /// 逻辑同Solution0924，只是将DFS查找连通分量改为了并查集
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="initial"></param>
        /// <returns></returns>
        public int MinMalwareSpread(int[][] graph, int[] initial)
        {
            if (initial.Length == 1) return initial[0];

            int n = graph.Length;
            UnionFind disjoint = new UnionFind(n);
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++) if (graph[i][j] == 1) disjoint.Union(i, j);
            Dictionary<int, HashSet<int>> sets = new Dictionary<int, HashSet<int>>();
            for (int i = 0, _key; i < n; i++)
            {
                _key = disjoint.Find(i);
                if (sets.ContainsKey(_key)) sets[_key].Add(i); else sets.Add(_key, new HashSet<int>() { i });
            }

            int result = initial.Min(), cnt = 0, _cnt, _id = int.MaxValue;
            HashSet<int> set = new HashSet<int>(initial);
            foreach (var _set in sets.Values)  // _set驱动set O(n)，set驱动_set O(n^2)
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

        private class UnionFind
        {
            public UnionFind(int n)
            {
                parents = new int[n];
                for (int i = 0; i < n; i++) parents[i] = i;
                sizes = new int[n];
                Array.Fill(sizes, 1);
            }

            private int[] parents;
            private int[] sizes;

            public int Find(int x)
            {
                if (parents[x] == x)
                {
                    return x;
                }
                else
                {
                    parents[x] = Find(parents[x]);
                    return parents[x];
                }
            }

            public void Union(int x, int y)
            {
                int rx = Find(x), ry = Find(y);
                if (rx != ry)
                {
                    if (sizes[rx] > sizes[ry])
                    {
                        parents[ry] = rx;
                        sizes[rx] += sizes[ry];
                    }
                    else
                    {
                        parents[rx] = ry;
                        sizes[ry] += sizes[rx];
                    }
                }
            }

            public int GetSize(int x)
            {
                return sizes[x];
            }
        }
    }
}
