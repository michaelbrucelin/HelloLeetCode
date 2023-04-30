using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1971
{
    public class Solution1971_3_2 : Interface1971
    {
        /// <summary>
        /// 与Solution1971_3一样，并查集实时压缩
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;

            int[] disjoint = new int[n];
            for (int i = 0; i < disjoint.Length; i++) disjoint[i] = i;
            for (int i = 0; i < edges.Length; i++)
            {
                Union(disjoint, edges[i][0], edges[i][1]);
                if (Find(disjoint, source) == Find(disjoint, destination)) return true;
            }

            return false;
        }

        private void Union(int[] disjoint, int v1, int v2)
        {
            int _v1 = Find(disjoint, v1), _v2 = Find(disjoint, v2);
            int _v = Math.Min(_v1, _v2);
            disjoint[_v1] = disjoint[_v2] = disjoint[v1] = disjoint[v2] = _v;
        }

        private int Find(int[] disjoint, int v)
        {
            Queue<int> queue = new Queue<int>();
            while (disjoint[v] != v)
            {
                queue.Enqueue(v); v = disjoint[v];
            }
            while (queue.Count > 0) disjoint[queue.Dequeue()] = v;

            return v;
        }
    }
}
