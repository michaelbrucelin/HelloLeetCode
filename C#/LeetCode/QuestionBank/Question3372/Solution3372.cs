using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3372
{
    public class Solution3372 : Interface3372
    {
        /// <summary>
        /// BFS
        /// 1. 第一棵树从节点i BFS k层即可
        /// 2. 第二棵树每个节点BFS k-1次，找出对多可以途径多少个节点
        /// </summary>
        /// <param name="edges1"></param>
        /// <param name="edges2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
        {
            int n1 = edges1.Length + 1, n2 = edges2.Length + 1;
            List<int>[] tree1 = new List<int>[n1], tree2 = new List<int>[n2];
            for (int i = 0; i < n1; i++) tree1[i] = new List<int>();
            foreach (int[] edge in edges1) { tree1[edge[0]].Add(edge[1]); tree1[edge[1]].Add(edge[0]); }
            for (int i = 0; i < n2; i++) tree2[i] = new List<int>();
            foreach (int[] edge in edges2) { tree2[edge[0]].Add(edge[1]); tree2[edge[1]].Add(edge[0]); }

            int[] result = new int[n1];
            // 计算tree1
            for (int i = 0; i < n1; i++) result[i] = bfs(tree1, i, k);
            // 计算tree2
            int maxcnt = 0;
            for (int i = 0; i < n2; i++) maxcnt = Math.Max(maxcnt, bfs(tree2, i, k - 1));

            for (int i = 0; i < n1; i++) result[i] += maxcnt;
            return result;

            int bfs(List<int>[] tree, int start, int step)
            {
                if (step < 0) return 0;
                if (step == 0) return 1;

                int cnt = 1;
                Queue<int> queue = new Queue<int>();
                bool[] visited = new bool[tree.Length];
                queue.Enqueue(start); visited[start] = true;
                int _cnt, _node;
                while (step-- > 0 && (_cnt = queue.Count) > 0)
                {
                    for (int i = 0; i < _cnt; i++)
                    {
                        _node = queue.Dequeue();
                        foreach (int next in tree[_node]) if (!visited[next])
                            {
                                queue.Enqueue(next); visited[next] = true; cnt++;
                            }
                    }
                }

                return cnt;
            }
        }

        /// <summary>
        /// 逻辑同MaxTargetNodes()，添加了剪枝
        /// k == 0, k >= n1, k>= n2，可以直接返回结果
        /// </summary>
        /// <param name="edges1"></param>
        /// <param name="edges2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxTargetNodes2(int[][] edges1, int[][] edges2, int k)
        {
            throw new NotImplementedException("");
        }
    }
}
