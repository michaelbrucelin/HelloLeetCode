using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3067
{
    public class Solution3067 : Interface3067
    {
        /// <summary>
        /// 暴力解
        /// 1. 遍历每一个顶点，以这个顶点为根计算结果
        /// 2. 查找顶点到每一颗子树中可连接节点数cnt，通过顶点每两棵子树可连接的数量为cnt1*cnt2
        /// 
        /// 可以考虑换根，但是这样需要记录当前根的每一颗子树中每个节点到根距离对signalSpeed的模
        /// 这样在换根时，复杂度与这样暴力解没本质区别，所以这里还是简单粗暴的解
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="signalSpeed"></param>
        /// <returns></returns>
        public int[] CountPairsOfConnectableServers(int[][] edges, int signalSpeed)
        {
            int n = edges.Length + 1;
            List<(int next, int weight)>[] graph = new List<(int next, int weight)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int next, int weight)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2])); graph[edge[1]].Add((edge[0], edge[2]));
            }

            int[] result = new int[n];
            List<int> cnts = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (graph[i].Count == 1) continue;
                cnts.Clear();
                for (int j = 0; j < graph[i].Count; j++) cnts.Add(CountPairs(graph, i, j, signalSpeed));
                for (int _i = 0; _i < cnts.Count; _i++) for (int _j = _i + 1; _j < cnts.Count; _j++)
                    {
                        result[i] += cnts[_i] * cnts[_j];
                    }
            }

            return result;
        }

        /// <summary>
        /// 计算子树中可连接节点数
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="root"></param>
        /// <param name="child"></param>
        /// <param name="signalSpeed"></param>
        /// <returns></returns>
        private int CountPairs(List<(int next, int weight)>[] graph, int root, int child, int signalSpeed)
        {
            int result = 0, n = graph.Length;
            bool[] visited = new bool[n]; visited[root] = true;
            Queue<(int node, int distance)> queue = new Queue<(int node, int distance)>();
            queue.Enqueue((graph[root][child].next, graph[root][child].weight));
            (int node, int distance) item;
            while (queue.Count > 0)
            {
                visited[(item = queue.Dequeue()).node] = true;
                if (item.distance % signalSpeed == 0) result++;
                for (int i = 0; i < graph[item.node].Count; i++) if (!visited[graph[item.node][i].next])
                    {
                        queue.Enqueue((graph[item.node][i].next, item.distance + graph[item.node][i].weight));
                    }
            }

            return result;
        }
    }
}
