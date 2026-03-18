using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0116
{
    public class Solution0116_2 : Interface0116
    {
        /// <summary>
        /// DisjointSet
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            int[] uf = new int[n], height = new int[n];
            for (int i = 1; i < n; i++) uf[i] = i;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++) if (isConnected[i][j] == 1) union(i, j);

            // HashSet<int> set = [];
            // for (int i = 0; i < n; i++) set.Add(find(i));
            // return set.Count;
            int result = 0;
            for (int i = 0; i < n; i++) if (uf[i] == i) result++;
            return result;

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                if (height[x] == height[y])
                {
                    uf[y] = x; height[x]++;
                }
                else
                {
                    if (height[x] > height[y]) uf[y] = x; else uf[x] = y;
                }
            }

            int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }
        }

        /// <summary>
        /// 逻辑同FindCircleNum()，将递归改为迭代
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum2(int[][] isConnected)
        {
            int n = isConnected.Length;
            int[] uf = new int[n], height = new int[n];
            for (int i = 1; i < n; i++) uf[i] = i;
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++) if (isConnected[i][j] == 1) union(i, j);

            // HashSet<int> set = [];
            // for (int i = 0; i < n; i++) set.Add(find(i));
            // return set.Count;
            int result = 0;
            for (int i = 0; i < n; i++) if (uf[i] == i) result++;
            return result;

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                if (height[x] == height[y])
                {
                    uf[y] = x; height[x]++;
                }
                else
                {
                    if (height[x] > height[y]) uf[y] = x; else uf[x] = y;
                }
            }

            int find(int x)
            {
                int f = x;
                while (uf[f] != f) f = uf[f];

                int i = x, j;
                while (uf[i] != f)
                {
                    j = uf[i]; uf[i] = f; i = j;
                }

                return uf[x];
            }
        }
    }
}
