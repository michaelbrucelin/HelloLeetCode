using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0111
{
    public class Solution0111 : Interface0111
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="equations"></param>
        /// <param name="values"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, List<(string, double)>> graph = new Dictionary<string, List<(string, double)>>();
            int cnt = equations.Count; string var1, var2; double val;
            for (int i = 0; i < cnt; i++)
            {
                (var1, var2, val) = (equations[i][0], equations[i][1], values[i]);
                // 验证过，题目的测试用例没有重复的，如果出现 a/b=10, a/b=20 这样的矛盾，以第一个为准
                if (graph.TryGetValue(var1, out var list1)) list1.Add((var2, val)); else graph.Add(var1, [(var2, val)]);
                val = 1 / val;
                if (graph.TryGetValue(var2, out var list2)) list2.Add((var1, val)); else graph.Add(var2, [(var1, val)]);
            }

            double[] result = new double[cnt = queries.Count];
            HashSet<string> visited = new HashSet<string>();
            for (int i = 0; i < cnt; i++)
            {
                (var1, var2) = (queries[i][0], queries[i][1]);
                if (!graph.ContainsKey(var1) || !graph.ContainsKey(var2)) { result[i] = -1; continue; }
                if (var1 == var2) { result[i] = 1; continue; }
                visited.Clear(); visited.Add(var1);
                result[i] = dfs(var1, var2);
            }

            return result;

            double dfs(string x, string y)
            {
                double r;
                foreach (var (next, val) in graph[x]) if (!visited.Contains(next))
                    {
                        if (next == y) return val;
                        visited.Add(next);
                        r = dfs(next, y);
                        if (r != -1) return val * r;  // 题目限定没有负数结果，所以这里用-1判断不会有错
                    }

                return -1;
            }
        }
    }
}
