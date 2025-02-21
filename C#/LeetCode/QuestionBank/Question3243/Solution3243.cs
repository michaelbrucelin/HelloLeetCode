using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3243
{
    public class Solution3243 : Interface3243
    {
        /// <summary>
        /// BFS
        /// 纯暴力，BFS解法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            HashSet<int>[] graph = new HashSet<int>[n - 1];
            for (int i = 0; i < n - 1; i++) graph[i] = new HashSet<int>() { i + 1 };

            int len = queries.Length;
            int[] result = new int[len];
            Queue<int> queue = new Queue<int>();
            bool[] mask = new bool[n - 1];
            for (int i = 0, _result = 0, _cnt = 0; i < len; i++)
            {
                graph[queries[i][0]].Add(queries[i][1]);
                if (graph[0].Contains(n - 1))
                {
                    for (int j = i; j < len; j++) result[j] = 1;
                    break;
                }

                _result = 0;
                queue.Clear(); queue.Enqueue(0); Array.Fill(mask, false);
                while (true)  // 一定有解，这里不做判断
                {
                    _result++;
                    _cnt = queue.Count;
                    for (int j = 0, _s; j < _cnt; j++)
                    {
                        _s = queue.Dequeue();
                        if (graph[_s].Contains(n - 1)) goto ENDLOOP;
                        foreach (int _next in graph[_s]) if (!mask[_next])
                            {
                                mask[_next] = true; queue.Enqueue(_next);
                            }
                    }
                }
            ENDLOOP:;
                result[i] = _result;
            }

            return result;
        }
    }
}
