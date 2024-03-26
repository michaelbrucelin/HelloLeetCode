using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2642
{
    public class Solution2642
    {
    }

    /// <summary>
    /// 迪杰斯特拉
    /// 
    /// 竟然通过了，本以为会TLE，可以先计算每两个点之间的最短路径，然后新增边有办法DP调整了
    /// </summary>
    public class Graph : Interface2642
    {
        public Graph(int n, int[][] edges)
        {
            this.n = n;
            graph = new List<(int next, int cost)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int next, int cost)>();
            foreach (var edge in edges) graph[edge[0]].Add((edge[1], edge[2]));
        }

        private int n;
        private List<(int next, int cost)>[] graph;

        public void AddEdge(int[] edge)
        {
            graph[edge[0]].Add((edge[1], edge[2]));
        }

        public int ShortestPath(int node1, int node2)
        {
            if (node1 == node2) return 0;

            int[] costs = new int[n]; Array.Fill(costs, -1);
            bool[] visited = new bool[n]; int visitcnt = 0;
            PriorityQueue<(int cost, int vid), int> minpq = new PriorityQueue<(int cost, int vid), int>();

            costs[node1] = 0; minpq.Enqueue((0, node1), 0);
            while (visitcnt < n && minpq.Count > 0)
            {
                while (minpq.Count > 0 && visited[minpq.Peek().vid]) minpq.Dequeue();
                if (minpq.Count == 0) break;
                var next = minpq.Dequeue();
                if (next.vid == node2) break;
                visited[next.vid] = true; visitcnt++; if (visitcnt == n) break;
                foreach (var u in graph[next.vid])
                {
                    if (!visited[u.next])
                    {
                        int _cost = costs[next.vid] + u.cost;
                        if (costs[u.next] == -1 || _cost < costs[u.next])
                        {
                            costs[u.next] = _cost; minpq.Enqueue((_cost, u.next), _cost);
                        }
                    }
                }
            }

            return costs[node2];
        }
    }
}
