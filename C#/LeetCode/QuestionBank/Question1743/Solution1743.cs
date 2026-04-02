using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1743
{
    public class Solution1743 : Interface1743
    {
        /// <summary>
        /// 哈希 + 
        /// 直觉上不需要回溯，只要“顺着”往下走，一定有结果，没有证明，先这样写出来试一试
        /// 
        /// 提交果然通过了，只有46个测试用例，不确认到底对不对，如果对，该怎样证明？欧拉回路？
        /// </summary>
        /// <param name="adjacentPairs"></param>
        /// <returns></returns>
        public int[] RestoreArray(int[][] adjacentPairs)
        {
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();
            foreach (int[] pair in adjacentPairs)
            {
                if (graph.TryGetValue(pair[0], out var map1))
                {
                    if (map1.TryGetValue(pair[1], out int cnt)) map1[pair[1]] = ++cnt; else map1.Add(pair[1], 1);
                }
                else
                {
                    graph.Add(pair[0], new Dictionary<int, int>() { { pair[1], 1 } });
                }

                if (graph.TryGetValue(pair[1], out var map2))
                {
                    if (map2.TryGetValue(pair[0], out int cnt)) map2[pair[0]] = ++cnt; else map2.Add(pair[0], 1);
                }
                else
                {
                    graph.Add(pair[1], new Dictionary<int, int>() { { pair[0], 1 } });
                }
            }

            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(adjacentPairs[0][0]);
            int x, y;
            while (graph.TryGetValue(list.Last.Value, out var next))
            {
                x = list.Last.Value; y = next.First().Key;
                list.AddLast(y);
                graph[x][y]--; if (graph[x][y] == 0) graph[x].Remove(y); if (graph[x].Count == 0) graph.Remove(x);
                graph[y][x]--; if (graph[y][x] == 0) graph[y].Remove(x); if (graph[y].Count == 0) graph.Remove(y);
            }
            while (graph.TryGetValue(list.First.Value, out var prev))
            {
                x = list.First.Value; y = prev.First().Key;
                list.AddFirst(y);
                graph[x][y]--; if (graph[x][y] == 0) graph[x].Remove(y); if (graph[x].Count == 0) graph.Remove(x);
                graph[y][x]--; if (graph[y][x] == 0) graph[y].Remove(x); if (graph[y].Count == 0) graph.Remove(y);
            }

            return [.. list];
        }
    }
}
