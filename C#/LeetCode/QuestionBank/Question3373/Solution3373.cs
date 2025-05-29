using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3373
{
    public class Solution3373 : Interface3373
    {
        /// <summary>
        /// 脑筋急转弯
        /// 换根DP + BFS
        /// 如果以节点 x 为根节点的树，距离为偶树节点的数目已知，那么只要知道节点 y 到节点 x 的距离是奇数还是偶数，就可以知道以 y 为根节点的树，距离为偶数节点的数目。
        /// </summary>
        /// <param name="edges1"></param>
        /// <param name="edges2"></param>
        /// <returns></returns>
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
        {
            int n1 = edges1.Length + 1, n2 = edges2.Length + 1;
            List<int>[] tree1 = new List<int>[n1], tree2 = new List<int>[n2];
            for (int i = 0; i < n1; i++) tree1[i] = new List<int>();
            foreach (int[] edge in edges1) { tree1[edge[0]].Add(edge[1]); tree1[edge[1]].Add(edge[0]); }
            for (int i = 0; i < n2; i++) tree2[i] = new List<int>();
            foreach (int[] edge in edges2) { tree2[edge[0]].Add(edge[1]); tree2[edge[1]].Add(edge[0]); }

            int[] result = new int[n1];
            Array.Fill(result, -1);
            int cnt1 = bfs(tree1, 0), cnt2 = bfs(tree2, 0); cnt2 = Math.Max(cnt2, n2 - cnt2);
            result[0] = cnt1;
            dfs(tree1, 0);
            if (cnt2 > 0) for (int i = 0; i < n1; i++) result[i] += cnt2;
            return result;

            int bfs(List<int>[] tree, int start)  // bfs找出以start为根节点的树，距离为偶数的节点数目
            {
                int even = 0, n = tree.Length;
                Queue<int> queue = new Queue<int>(); queue.Enqueue(start);
                bool[] visited = new bool[n]; visited[start] = true;
                bool flag = true;
                int q_cnt, q_item;
                while ((q_cnt = queue.Count) > 0)
                {
                    if (flag) even += q_cnt; flag = !flag;
                    for (int i = 0; i < q_cnt; i++)
                    {
                        q_item = queue.Dequeue();
                        foreach (int next in tree[q_item]) if (!visited[next])
                            {
                                queue.Enqueue(next); visited[next] = true;
                            }
                    }
                }

                return even;
            }

            void dfs(List<int>[] tree, int node)  // dfs计算结果，bfs也可以
            {
                int n = tree.Length;
                foreach (int next in tree[node]) if (result[next] == -1)
                    {
                        result[next] = n - result[node];
                        dfs(tree, next);
                    }
            }
        }
    }
}
