using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0116
{
    public class Solution0116 : Interface0116
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length, result = 0;
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++) if (!visited[i])
                {
                    result++; visited[i] = true; dfs(i);
                }

            return result;

            void dfs(int x)
            {
                for (int i = 0; i < n; i++) if (isConnected[x][i] == 1 && !visited[i])
                    {
                        visited[i] = true; dfs(i);
                    }
            }
        }
    }
}
