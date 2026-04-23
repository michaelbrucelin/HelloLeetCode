using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2467
{
    public class Solution2467 : Interface2467
    {
        /// <summary>
        /// 模拟
        /// Alice BFS模拟即可，Bob需要先处理出路径，再模拟
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="bob"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            int n = edges.Length + 1;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) { graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); }
            bool[] visited = new bool[n];
            Stack<int> stack = new Stack<int>();
            backtrack(0);                         // 找出bob的路径

            int result = 0, cnt, node;
            Queue<int> queue = new Queue<int>(); queue.Enqueue(0);
            Array.Fill(visited, false);
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    if (visited[node = queue.Dequeue()]) continue;
                }
            }

            return result;

            bool backtrack(int node)
            {
                if (visited[node]) return false;
                stack.Push(node); visited[node] = true;
                if (node == bob) return true;
                foreach (int next in graph[node])
                {
                    if (backtrack(next)) return true;
                    stack.Pop();
                }

                return false;
            }
        }
    }
}
