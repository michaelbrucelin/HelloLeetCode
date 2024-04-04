using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2192
{
    public class Solution2192_3 : Interface2192
    {
        /// <summary>
        /// 拓扑排序
        /// 一层一层往下拨，拨下来的加入到下一个节点的结果集中
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            int[] indeg = new int[n];
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]); indeg[edge[1]]++;
            }
            Queue<int> deg0 = new Queue<int>();
            for (int i = 0; i < n; i++) if (indeg[i] == 0) deg0.Enqueue(i);

            HashSet<int>[] cache = new HashSet<int>[n];
            for (int i = 0; i < n; i++) cache[i] = new HashSet<int>();
            int v;
            while (deg0.Count > 0)
            {
                v = deg0.Dequeue();
                foreach (int _v in graph[v])
                {
                    cache[_v].Add(v);
                    cache[_v].UnionWith(cache[v]);
                    if (--indeg[_v] == 0) deg0.Enqueue(_v);
                }
            }

            List<int>[] result = new List<int>[n];
            for (int i = 0; i < n; i++) result[i] = cache[i].OrderBy(x => x).ToList();
            return result;
        }
    }
}
