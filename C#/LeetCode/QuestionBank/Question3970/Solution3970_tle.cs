using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3970
{
    public class Solution3970_tle : Interface3970
    {
        /// <summary>
        /// BFS
        /// 1. 需要记录
        ///     当前路径途径了哪些顶点，防止有环
        ///     当前路径最后一个字符连续多少个，不能超过k
        ///     当前路径总权重，结果
        /// 感觉会MLE，这个问题可以通过回溯来减少内存占用，先写出来试试
        /// 
        /// 测试用例04没跑完，也不知道代码除了效率慢还有没有其它问题，leetcode平台上的通过率为：629 / 1001，然后就TLE了
        /// 不就结了，直接改用Dijkstra解决
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="labels"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestPath(int n, int[][] edges, string labels, int k)
        {
            List<(int, int)>[] graph = new List<(int, int)>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) graph[edge[0]].Add((edge[1], edge[2]));

            int result = int.MaxValue;
            // node, weight, lastchar, lastchar count, path
            Queue<(int, int, char, int, HashSet<int>)> queue = new Queue<(int, int, char, int, HashSet<int>)>();
            queue.Enqueue((0, 0, labels[0], 1, [0]));
            int node, weight; char c; int cnt; HashSet<int> path;
            while (queue.Count > 0)
            {
                (node, weight, c, cnt, path) = queue.Dequeue();
                if (node == n - 1) { result = Math.Min(result, weight); continue; }
                foreach ((int next, int w) in graph[node])
                {
                    if (path.Contains(next)) continue;
                    if (labels[next] == c)
                    {
                        if (cnt + 1 <= k) queue.Enqueue((next, weight + w, c, cnt + 1, [.. path, next]));
                    }
                    else
                    {
                        queue.Enqueue((next, weight + w, labels[next], 1, [.. path, next]));
                    }
                }
            }

            return result != int.MaxValue ? result : -1;
        }
    }
}
