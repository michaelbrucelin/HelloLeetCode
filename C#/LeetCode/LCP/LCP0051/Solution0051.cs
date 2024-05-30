using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0051
{
    public class Solution0051 : Interface0051
    {
        /// <summary>
        /// DFS + 回溯
        /// 数据量不大，直接DFS + 回溯即可
        /// </summary>
        /// <param name="materials"></param>
        /// <param name="cookbooks"></param>
        /// <param name="attribute"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int PerfectMenu(int[] materials, int[][] cookbooks, int[][] attribute, int limit)
        {
            int result = -1;
            dfs(materials, cookbooks, attribute, limit, 0, 0, 0, ref result);

            return result;
        }

        private void dfs(int[] materials, int[][] cookbooks, int[][] attribute, int limit, int id, int delicious, int filling, ref int result)
        {
            if (id == cookbooks.Length) return;

            // 不做cookbooks[id]
            dfs(materials, cookbooks, attribute, limit, id + 1, delicious, filling, ref result);

            // 做cookbooks[id]
            bool flag = true;
            for (int i = 0; i < 5; i++) if ((materials[i] -= cookbooks[id][i]) < 0) flag = false;
            delicious += attribute[id][0]; filling += attribute[id][1];
            if (flag)
            {
                if (filling >= limit) result = Math.Max(result, delicious);
                dfs(materials, cookbooks, attribute, limit, id + 1, delicious, filling, ref result);
            }
            for (int i = 0; i < 5; i++) materials[i] += cookbooks[id][i];  // 回溯
        }
    }
}
