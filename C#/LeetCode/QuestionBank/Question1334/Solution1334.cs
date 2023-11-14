using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1334
{
    public class Solution1334 : Interface1334
    {
        /// <summary>
        /// 最短路径，迪杰斯特拉
        /// 题目限定顶点数不超过100，这里使用邻接矩阵的方式构建图
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="distanceThreshold"></param>
        /// <returns></returns>
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            int[,] graph = new int[n, n];
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) graph[i, j] = -1;
            foreach (var edge in edges)
            {
                graph[edge[0], edge[1]] = edge[2]; graph[edge[1], edge[0]] = edge[2];
            }

            int result = -1, maxcnt = n + 1; int[] weight;
            for (int v = n - 1, _cnt; v >= 0; v--)
            {
                weight = SP_Dijkstra(n, graph, v);
                _cnt = 0; for (int i = 0; i < n; i++) if (weight[i] <= distanceThreshold) _cnt++;
                if (_cnt == 1) return v;
                if (_cnt < maxcnt) { result = v; maxcnt = _cnt; }
            }

            return result;
        }

        private int[] SP_Dijkstra(int n, int[,] graph, int start)
        {
            int[] weights = new int[n]; Array.Fill(weights, -1);
            bool[] visited = new bool[n]; int visitcnt;
            PriorityQueue<(int weight, int vid), int> minpq = new PriorityQueue<(int weight, int vid), int>();

            int ptr = start; weights[start] = 0; visited[start] = true; visitcnt = 1;
            while (visitcnt < n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i] && graph[ptr, i] != -1)
                    {
                        int _weight = weights[ptr] + graph[ptr, i];
                        if (weights[i] == -1 || _weight < weights[i])
                        {
                            weights[i] = _weight; minpq.Enqueue((_weight, i), _weight);
                        }
                    }
                }
                while (minpq.Count > 0 && visited[minpq.Peek().vid]) minpq.Dequeue();
                if (minpq.Count == 0) break;
                var next = minpq.Dequeue();
                visited[next.vid] = true; visitcnt++;
                ptr = next.vid;
            }

            return weights;
        }
    }
}
