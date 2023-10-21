using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2316
{
    public class Solution2316_2 : Interface2316
    {
        /// <summary>
        /// 并查集
        /// 本质上就是找出各个连通子图中的顶点数量
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public long CountPairs(int n, int[][] edges)
        {
            int[] uf = new int[n];
            for (int i = 0; i < n; i++) uf[i] = i;
            foreach (var arr in edges)
            {
                int minid = Math.Min(uf[arr[0]], uf[arr[1]]);
                int i = arr[0], j;
                while (uf[i] != minid) { j = uf[i]; uf[i] = minid; i = j; }
                i = arr[1];
                while (uf[i] != minid) { j = uf[i]; uf[i] = minid; i = j; }
            }

            Dictionary<int, int> group = new Dictionary<int, int>();
            for (int i = 0, j; i < n; i++)
            {
                j = i;
                while (uf[j] != j) j = uf[j];
                if (group.ContainsKey(j)) group[j]++; else group.Add(j, 1);
            }

            long result = 0;
            foreach (int cnt in group.Values) result += ((long)cnt) * (n - cnt);
            return result >> 1;
        }
    }
}
