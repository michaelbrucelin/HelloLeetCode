using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1761
{
    public class Solution1761 : Interface1761
    {
        /// <summary>
        /// 暴力解
        /// 1. 预处理，将edges处理为map：Dictionary<int, HashSet<int>>的形式，key是顶点，value是邻边
        /// 2. 两层循环找出所有顶点的两两组合(i, j)，O(n^2)
        ///     如果i与j想连，遍历map[i]与map[j]的交集k，map[i].Count + map[j].Count + map[k].Count - 6就是一个结果
        /// 总时间复杂度O(n^3)，竟然AC了，没有TLE
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int MinTrioDegree(int n, int[][] edges)
        {
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            for (int i = 0, x = 0, y = 0; i < edges.Length; i++)
            {
                x = edges[i][0]; y = edges[i][1];
                if (map.ContainsKey(x)) map[x].Add(y); else map.Add(x, new HashSet<int>() { y });
                if (map.ContainsKey(y)) map[y].Add(x); else map.Add(y, new HashSet<int>() { x });
            }

            int result = n * n, _r;
            foreach (int i in map.Keys) foreach (int j in map.Keys)
                {
                    if (j <= i || !map[i].Contains(j)) continue;
                    _r = map[i].Count + map[j].Count - 6;
                    if (_r >= result - 2) continue;
                    foreach (int k in map[i].Intersect(map[j]))
                    {
                        result = Math.Min(result, _r + map[k].Count);
                        if (result == 0) return 0;
                    }
                }

            return result != n * n ? result : -1;
        }
    }
}
