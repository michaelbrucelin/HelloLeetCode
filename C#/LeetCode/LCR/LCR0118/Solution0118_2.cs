using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0118
{
    public class Solution0118_2 : Interface0118
    {
        /// <summary>
        /// 并查集
        /// 逻辑同Solution0118，将路径压缩中的递归改为迭代
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            int[] uf = new int[n + 1], height = new int[n + 1];
            for (int i = 1; i <= n; i++) uf[i] = i;
            foreach (int[] edge in edges) if (union(edge[0], edge[1])) return edge;

            return null;

            bool union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return true;
                if (height[x] == height[y])
                {
                    uf[y] = x; height[x]++;
                }
                else
                {
                    if (height[x] > height[y]) uf[y] = x; else uf[x] = y;
                }

                return false;
            }

            int find(int x)
            {
                int y = x;
                while (y != uf[y]) y = uf[y];
                int i = x, j;
                while (uf[i] != y)
                {
                    j = uf[i]; uf[i] = y; i = j;
                }

                return uf[x];
            }
        }
    }
}
