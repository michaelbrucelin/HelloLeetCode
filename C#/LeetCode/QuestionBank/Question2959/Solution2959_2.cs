using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2959
{
    public class Solution2959_2 : Interface2959
    {
        /// <summary>
        /// 二进制枚举 + Floyd
        /// 逻辑同Solution2959，缩小了图的规模
        /// 例如总共100个点，但是只选择了10个点，Solution2959中依然是100个点图，这里创建10个点的图
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxDistance"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int NumberOfSets(int n, int maxDistance, int[][] roads)
        {
            int result = 0, all = 1 << n, infty = int.MaxValue;
            int[,] graph = new int[n, n];                                                                              // 创建邻接矩阵
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) graph[i, j] = i == j ? 0 : infty;
            foreach (var road in roads)
            {
                graph[road[0], road[1]] = Math.Min(graph[road[0], road[1]], road[2]);
                graph[road[1], road[0]] = Math.Min(graph[road[1], road[0]], road[2]);
            }

            int[,] _graph = new int[n, n];
            List<int> choose = new List<int>();
            for (int mask = 0, _n; mask < all; mask++)                                                                 // 二进制枚举每一种关闭方案
            {
                choose.Clear();
                for (int i = 0; i < n; i++) if (((mask >> i) & 1) == 1) choose.Add(i);
                _n = choose.Count;
                for (int i = 0; i < _n; i++) for (int j = 0; j < _n; j++) _graph[i, j] = graph[choose[i], choose[j]];  // 初始化邻接矩阵

                for (int k = 0; k < _n; k++) for (int i = 0; i < _n; i++) for (int j = 0; j < _n; j++)
                        {
                            if (_graph[i, k] != infty && _graph[k, j] != infty) _graph[i, j] = Math.Min(_graph[i, j], _graph[i, k] + _graph[k, j]);
                        }

                for (int i = 0; i < _n; i++) for (int j = 0; j < _n; j++)
                    {
                        if (_graph[i, j] > maxDistance) goto CONTINUE;
                    }
                result++;
                CONTINUE:;
            }

            return result;
        }
    }
}
