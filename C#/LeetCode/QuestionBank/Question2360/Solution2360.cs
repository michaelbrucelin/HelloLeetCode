using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2360
{
    public class Solution2360 : Interface2360
    {
        /// <summary>
        /// 遍历，类拓扑排序
        /// 1. 题目限定每个节点至多有一个出度，所以，不存在相交的环
        /// 2. 类拓扑排序，移除入读为0的节点，直到没有节点可以移除
        ///     剩下就是环
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int LongestCycle(int[] edges)
        {
            int n = edges.Length;
            Dictionary<int, HashSet<int>> ins = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++) ins.Add(i, new HashSet<int>());
            for (int i = 0, j = -1; i < n; i++)
            {
                if ((j = edges[i]) == -1) continue;
                ins[j].Add(i);
            }

            // 类拓扑排序，移除入读为0的节点
            for (int i = 0, j = -1; i < n; i++)
            {
                j = i;
                while (ins.ContainsKey(j) && ins[j].Count == 0)
                {
                    ins.Remove(j);
                    if (edges[j] == -1) break;
                    ins[edges[j]].Remove(j);
                    j = edges[j];
                }
            }

            int result = -1, _result, _next;
            HashSet<int> visited = new HashSet<int>();
            foreach (int node in ins.Keys) if (!visited.Contains(node))
                {
                    _result = 1; _next = edges[node];
                    while (_next != node)
                    {
                        _result++; visited.Add(_next); _next = edges[_next];
                    }
                    visited.Add(node);
                    result = Math.Max(result, _result);
                }

            return result;
        }
    }
}
