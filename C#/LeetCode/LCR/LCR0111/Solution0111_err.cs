using LeetCode.QuestionBank.Question2642;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0111
{
    public class Solution0111_err : Interface0111
    {
        /// <summary>
        /// 类并查集
        /// 借助并查集的思想将变量分组，注意不要压缩路径，merge(x,y)时，往更小的树根上挂
        /// 
        /// 还是有问题，应该可以通过并查集实现，有时间重新写
        /// </summary>
        /// <param name="equations"></param>
        /// <param name="values"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, string> uf = new Dictionary<string, string>();
            int cnt = equations.Count; string var1, var2; double val;
            for (int i = 0; i < cnt; i++)
            {
                (var1, var2, val) = (equations[i][0], equations[i][1], values[i]);
                // 验证过，题目的测试用例没有重复的，如果出现 a/b=10, a/b=20 这样的矛盾，以第一个为准
                if (graph.TryGetValue(var1, out var map1)) map1.Add(var2, val); else graph.Add(var1, new Dictionary<string, double>() { { var2, val } });
                val = 1 / val;
                if (graph.TryGetValue(var2, out var map2)) map2.Add(var1, val); else graph.Add(var2, new Dictionary<string, double>() { { var1, val } });

                uf.TryAdd(var1, var1);
                uf.TryAdd(var2, var2);
                union(var1, var2);
            }

            double[] result = new double[cnt = queries.Count];
            double c1, c2;
            for (int i = 0; i < cnt; i++)
            {
                (var1, var2) = (queries[i][0], queries[i][1]);
                if (!graph.ContainsKey(var1) || !graph.ContainsKey(var2)) { result[i] = -1; continue; }
                if (var1 == var2) { result[i] = 1; continue; }
                c1 = c2 = 1;
                while (uf[var1] != var1) { c1 *= graph[var1][uf[var1]]; var1 = uf[var1]; }
                while (uf[var2] != var2) { c2 *= graph[var2][uf[var2]]; var2 = uf[var2]; }
                result[i] = var1 != var2 ? -1 : c1 / c2;
            }

            return result;

            void union(string x, string y)
            {
                switch (string.CompareOrdinal(x, y))
                {
                    case < 0: uf[y] = x; break;
                    case > 0: uf[x] = y; break;
                    default: break;
                }
            }
        }
    }
}
