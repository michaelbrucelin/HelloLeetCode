using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2477
{
    public class Solution2477 : Interface2477
    {
        /// <summary>
        /// 递归
        /// 每个节点都等于所有后代节点的和，以及后代节点到当前节点的和
        /// </summary>
        /// <param name="roads"></param>
        /// <param name="seats"></param>
        /// <returns></returns>
        public long MinimumFuelCost(int[][] roads, int seats)
        {
            if (roads.Length == 0) return 0;
            if (roads.Length == 1) return 1;

            // 构造图/树
            int n = roads.Length + 1;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                graph[roads[i][0]].Add(roads[i][1]); graph[roads[i][1]].Add(roads[i][0]);
            }

            return rec(graph, -1, 0, seats).gas;
        }

        private (long gas, int person) rec(List<int>[] graph, int last, int curr, decimal seats)
        {
            if (graph[curr].Count == 1 && curr != 0) return (0, 1);

            long gas = 0; int person = 0;
            (long gas, int person) _t;
            for (int i = 0; i < graph[curr].Count; i++)
            {
                if (graph[curr][i] == last) continue;
                _t = rec(graph, curr, graph[curr][i], seats);
                person += _t.person; gas += _t.gas;
                gas += (int)Math.Ceiling(_t.person / seats);
            }

            return (gas, person + 1);
        }
    }
}
