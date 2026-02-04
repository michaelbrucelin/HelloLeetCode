using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0110
{
    public class Solution0110_2 : Interface0110
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int n = graph.Length;
            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue([0]);
            List<int> item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (item[^1] == n - 1) { result.Add(item); continue; }
                foreach (int next in graph[item[^1]]) queue.Enqueue([.. item, next]);
            }

            return result;
        }
    }
}
