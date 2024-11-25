using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0743
{
    public class Solution0743 : Interface0743
    {
        /// <summary>
        /// BFS
        /// 暴力解法，写着玩的，应该用Dijkstra算法实现的
        /// </summary>
        /// <param name="times"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            List<(int vid, int weight)>[] graph = new List<(int vid, int weight)>[++n];
            for (int i = 1; i < n; i++) graph[i] = new List<(int vid, int weight)>();
            foreach (int[] edge in times) graph[edge[0]].Add((edge[1], edge[2]));

            (bool visit, int time)[] visited = new (bool visit, int time)[n];
            Queue<(int vid, int time)> queue = new Queue<(int vid, int time)>();
            queue.Enqueue((k, 0));
            (int vid, int time) item; int cnt;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    if (visited[item.vid].visit && item.time >= visited[item.vid].time) continue;
                    visited[item.vid] = (true, item.time);
                    foreach (var next in graph[item.vid]) queue.Enqueue((next.vid, item.time + next.weight));
                }
            }

            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (!visited[i].visit) return -1;
                result = Math.Max(result, visited[i].time);
            }
            return result;
        }
    }
}
