using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0797
{
    public class Solution0797_2 : Interface0797
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            // if (graph.Length < 2) return [];  // 题目限定图不少于两个节点

            int n = graph.Length;
            IList<IList<int>> result = [];
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
