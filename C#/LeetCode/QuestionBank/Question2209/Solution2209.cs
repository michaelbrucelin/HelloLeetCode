using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2209
{
    public class Solution2209 : Interface2209
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 1. 覆盖第i个位置的白色瓷砖，从i+carpetLen个位置继续
        /// 2. 不覆盖第i个位置的白色瓷砖，从i+1个位置继续
        /// 
        /// 预处理
        /// 1. 重新确认左右边界，即左侧第一个白色瓷砖为起点，右侧第一个白色瓷砖为终点
        /// 2. 后缀和优化计算后缀区间白色瓷砖的数量
        /// 3. 每个位置下一个白色瓷砖的位置
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="numCarpets"></param>
        /// <param name="carpetLen"></param>
        /// <returns></returns>
        public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen)
        {
            // 确认左右边界
            int s = 0, e = floor.Length - 1, n = floor.Length;
            while (s <= e && floor[s] == '0') s++;
            if (s > e) return 0;
            while (e >= s && floor[e] == '0') e--;
            if (numCarpets * carpetLen > e - s) return 0;

            // 预处理后缀和
            int[] cnts = new int[e + 2];
            for (int i = e; i >= s; i--) cnts[i] = cnts[i + 1] + (floor[i] - '0');

            // 下一个白色瓷砖的位置
            int[] next = new int[n];
            Array.Fill(next, int.MaxValue, e, n - e);
            for (int i = e - 1, j = e; i >= s; i--) { next[i] = j; if (floor[i] == '1') j = i; }
            Array.Fill(next, s, 0, s);

            // DFS + 记忆化搜索
            Dictionary<(int x, int y), int> memory = new Dictionary<(int x, int y), int>();
            return dfs(s, numCarpets);

            int dfs(int x, int y)  // x: 当前位置 y: 剩余地毯数
            {
                if (x > e) return 0;
                if (y == 0) return cnts[x];
                if (memory.ContainsKey((x, y))) return memory[(x, y)];

                int result = Math.Min(
                    dfs(next[Math.Min(x + carpetLen - 1, n - 1)], y - 1),  // 覆盖x
                    dfs(next[x], y) + 1                                    // 不覆盖x
                );

                memory.Add((x, y), result);
                return result;
            }
        }
    }
}
