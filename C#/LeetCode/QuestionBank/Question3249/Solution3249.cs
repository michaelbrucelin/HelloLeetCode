using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3249
{
    public class Solution3249 : Interface3249
    {
        /// <summary>
        /// DFS
        /// 1. 先将边数组转为HashSet<int>[]的形式
        /// 2. DFS无向图转为有向图（树），即有了0 -> x，就删除x -> 0
        /// 3. DFS统计每个节点为根的子树的节点数量
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int CountGoodNodes(int[][] edges)
        {
            int n = edges.Length + 1;
            HashSet<int>[] tree = new HashSet<int>[n];  // 无向图
            for (int i = 0; i < n; i++) tree[i] = new HashSet<int>();
            foreach (int[] edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }
            ToTree(0);  // 将无向图转为有向图

            int[] cnts = new int[n];
            Array.Fill(cnts, -1);
            _CountGoodNodes(0);

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                if (tree[i].Count < 2)
                {
                    result++;
                }
                else
                {
                    int _cnt = cnts[tree[i].First()];
                    foreach (int next in tree[i]) if (cnts[next] != _cnt) goto CONTINUE;
                    result++;
                }
            CONTINUE:;
            }
            return result;

            void ToTree(int id)
            {
                foreach (int next in tree[id])
                {
                    tree[next].Remove(id);
                    ToTree(next);
                }
            }

            void _CountGoodNodes(int id)
            {
                if (tree[id].Count == 0) { cnts[0] = 0; return; }
                foreach (int next in tree[id])
                {
                    if (cnts[next] == -1) _CountGoodNodes(next);
                    cnts[id] += cnts[next];
                }
            }
        }
    }
}
