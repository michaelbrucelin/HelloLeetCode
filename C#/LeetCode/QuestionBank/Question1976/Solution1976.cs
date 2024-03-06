using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1976
{
    public class Solution1976 : Interface1976
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int CountPaths(int n, int[][] roads)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var road in roads)
            {
                graph[road[0]].Add(road[1]); graph[road[1]].Add(road[0]);
            }

            throw new NotImplementedException();
        }
    }
}
