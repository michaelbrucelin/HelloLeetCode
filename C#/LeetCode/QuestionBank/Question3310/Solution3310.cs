using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3310
{
    public class Solution3310 : Interface3310
    {
        /// <summary>
        /// DFS + 多源BFS
        /// 先DFS找出所有被感染的方法，再从这些方法为起点多源BFS看是否可到达没被感染的方法即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="invocations"></param>
        /// <returns></returns>
        public IList<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            List<int>[] graph1 = new List<int>[n], graph2 = new List<int>[n];
            for (int i = 0; i < n; i++) { graph1[i] = []; graph2[i] = []; }
            foreach (int[] e in invocations) { graph1[e[0]].Add(e[1]); graph2[e[1]].Add(e[0]); }

            bool[] visited = new bool[n];
            HashSet<int> infection = [];
            dfs(k, n, graph1, infection, visited);

            bool flag = false;
            foreach (int x in infection) foreach (int y in graph2[x]) if (!infection.Contains(y))
                    {
                        flag = true;
                        goto ENDFOREACH;
                    }
                ENDFOREACH:;

            List<int> result = [];
            if (flag)
            {
                for (int i = 0; i < n; i++) result.Add(i);
            }
            else
            {
                for (int i = 0; i < n; i++) if (!infection.Contains(i)) result.Add(i);
            }
            return result;

            static void dfs(int x, int n, List<int>[] graph, HashSet<int> set, bool[] mask)
            {
                if (mask[x]) return; mask[x] = true;

                set.Add(x);
                foreach (int y in graph[x]) dfs(y, n, graph, set, mask);
            }
        }
    }
}
