using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1615
{
    public class Solution1615_2 : Interface1615
    {
        /// <summary>
        /// 邻接矩阵 + 枚举
        /// </summary>
        /// <param name="n"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            int[,] connect = new int[n, n];
            int[] degree = new int[n];
            for (int i = 0; i < roads.Length; i++)
            {
                connect[roads[i][0], roads[i][1]] = 1; connect[roads[i][1], roads[i][0]] = 1;
                degree[roads[i][0]]++; degree[roads[i][1]]++;
            }

            int result = 0;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    result = Math.Max(result, degree[i] + degree[j] - connect[i, j]);
                }

            return result;
        }
    }
}
