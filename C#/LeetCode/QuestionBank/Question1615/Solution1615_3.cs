using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1615
{
    public class Solution1615_3 : Interface1615
    {
        /// <summary>
        /// 邻接矩阵 + 枚举优化
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

            int first = -1, second = -2;
            List<int> firstArr = new List<int>(), secondArr = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (degree[i] > first)
                {
                    second = first; secondArr = new List<int>(firstArr);
                    first = degree[i]; firstArr.Clear(); firstArr.Add(i);
                }
                else if (degree[i] == first)
                {
                    firstArr.Add(i);
                }
                else if (degree[i] > second)
                {
                    second = degree[i]; secondArr.Clear(); secondArr.Add(i);
                }
                else if (degree[i] == second)
                {
                    secondArr.Add(i);
                }
            }

            int result;
            if (firstArr.Count > 1)
            {
                if ((firstArr.Count * (firstArr.Count - 1)) >> 1 > roads.Length) return first << 1;
                result = (first << 1) - 1;
                for (int i = 0; i < firstArr.Count; i++) for (int j = i + 1; j < firstArr.Count; j++)
                        if (connect[firstArr[i], firstArr[j]] != 1) return result + 1;
            }
            else  // if (firstArr.Count == 1)
            {
                result = first + second - 1;
                for (int i = 0; i < secondArr.Count; i++)
                    if (connect[firstArr[0], secondArr[i]] != 1) return result + 1;
            }

            return result;
        }
    }
}
