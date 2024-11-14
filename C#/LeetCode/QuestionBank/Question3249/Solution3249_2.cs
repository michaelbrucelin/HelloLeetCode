using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3249
{
    public class Solution3249_2 : Interface3249
    {
        /// <summary>
        /// BFS
        /// 这里使用BFS将无向图转为双向树，即普通的根到叶子的树，以及叶子到根的“树”，记录节点的“层”
        /// 这样叶子到根的树，节点从下层向上层遍历，即可计算出每个节点为根的子树的节点的数量
        /// 叶子到根的树使用数组存储，最大层数为n
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int CountGoodNodes(int[][] edges)
        {
            int n = edges.Length + 1;
            HashSet<int>[] tree = new HashSet<int>[n];
            for (int i = 0; i < n; i++) tree[i] = new HashSet<int>();
            foreach (int[] edge in edges)
            {
                tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]);
            }

            List<(int id, int pid)>[] eert = new List<(int id, int pid)>[n];  // 叶子到根的树，分层储存，最多n层
            Queue<int> queue = new Queue<int>(); queue.Enqueue(0);
            int cnt, level = 0, item;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    foreach (int next in tree[item])
                    {
                        tree[next].Remove(item);
                        if (eert[level] == null)
                            eert[level] = new List<(int id, int pid)>() { (next, item) };
                        else
                            eert[level].Add((next, item));
                        queue.Enqueue(next);
                    }
                }
                level++;
            }

            // 自底向上逐层统计子树的节点数量
            int[] cnts = new int[n];
            Array.Fill(cnts, 1);
            for (int i = n - 1; i >= 0; i--) if (eert[i] != null) foreach (var info in eert[i])
                    {
                        cnts[info.pid] += cnts[info.id];
                    }

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
        }
    }
}
