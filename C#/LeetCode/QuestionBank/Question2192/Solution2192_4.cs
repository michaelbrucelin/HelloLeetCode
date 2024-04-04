using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2192
{
    public class Solution2192_4 : Interface2192
    {
        /// <summary>
        /// 拓扑排序
        /// 逻辑与Solution2192_3一样，只是将HashSet换成了基础的数组
        ///     这样做稀疏图的话会严重增加空间复杂度，但是会优化排序带来的时间复杂度
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

            bool[,] cache = new bool[n, n];
            int v;
            while (deg0.Count > 0)
            {
                v = deg0.Dequeue();
                foreach (int _v in graph[v])
                {
                    cache[_v, v] = true;
                    for (int i = 0; i < n; i++) if (cache[v, i]) cache[_v, i] = true;
                    if (--indeg[_v] == 0) deg0.Enqueue(_v);
                }
            }

            List<int>[] result = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = new List<int>();
                for (int j = 0; j < n; j++) if (cache[i, j]) result[i].Add(j);
            }
            return result;
        }
    }
}
