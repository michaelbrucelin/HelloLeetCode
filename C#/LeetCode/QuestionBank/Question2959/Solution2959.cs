using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2959
{
    public class Solution2959 : Interface2959
    {
        /// <summary>
        /// 二进制枚举 + Floyd
        /// 1. 题目限定最多有10个分部，也就是最多有1024种关闭分部的方案，可以使用二进制枚举来枚举每一种方案
        /// 2. 对于每一种关闭方案，使用Floyd来计算两两分部之间的最短路径
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxDistance"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int NumberOfSets(int n, int maxDistance, int[][] roads)
        {
            int result = 0, all = 1 << n, infty = int.MaxValue;
            int[,] graph = new int[n, n];                                                              // 创建邻接矩阵
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) graph[i, j] = i == j ? 0 : infty;
            foreach (var road in roads)
            {
                graph[road[0], road[1]] = Math.Min(graph[road[0], road[1]], road[2]);
                graph[road[1], road[0]] = Math.Min(graph[road[1], road[0]], road[2]);
            }

            int[,] _graph = new int[n, n];
            List<int> choose = new List<int>();
            for (int mask = 0; mask < all; mask++)                                                     // 二进制枚举每一种关闭方案
            {
                for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) _graph[i, j] = graph[i, j];    // 初始化邻接矩阵
                choose.Clear();
                for (int i = 0; i < n; i++)
                {
                    if (((mask >> i) & 1) == 0)                                                        // 移除没有选中的分部的对应路径
                    {
                        for (int j = 0; j < n; j++) if (j != i) _graph[i, j] = _graph[j, i] = infty;
                    }
                    else
                    {
                        choose.Add(i);
                    }
                }
                for (int k = 0; k < n; k++) for (int i = 0; i < n; i++) for (int j = 0; j < n; j++)
                        {
                            if (_graph[i, k] != infty && _graph[k, j] != infty) _graph[i, j] = Math.Min(_graph[i, j], _graph[i, k] + _graph[k, j]);
                        }

                for (int i = 0; i < choose.Count; i++) for (int j = 0; j < choose.Count; j++)
                    {
                        if (_graph[choose[i], choose[j]] > maxDistance) goto CONTINUE;
                    }
                result++;
                CONTINUE:;
            }

            return result;
        }
    }
}
