using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1444
{
    public class Solution1444 : Interface1444
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// 前缀和 + DFS + 记忆化搜索
        /// 1. 前缀和可以迅速判断切的区域以及剩余的区域是否有苹果
        /// 2. DFS + 记忆化搜索去寻找答案
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Ways(string[] pizza, int k)
        {
            int rcnt = pizza.Length, ccnt = pizza[0].Length;
            int[,] pre = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1, c + 1] = pre[r, c + 1] + pre[r + 1, c] - pre[r, c] + (pizza[r][c] & 1);
                }
            int[,,] memory = new int[rcnt, ccnt, k];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) for (int z = 0; z < k; z++) memory[r, c, z] = -1;

            return dfs(pizza, 0, 0, k - 1, pre, memory);
        }

        private int dfs(string[] pizza, int r, int c, int k, int[,] pre, int[,,] memory)
        {
            if (k < 0) return 0;
            if (memory[r, c, k] != -1) return memory[r, c, k];

            int rcnt = pizza.Length, ccnt = pizza[0].Length;
            if (pre[rcnt, ccnt] - pre[r, ccnt] - pre[rcnt, c] + pre[r, c] <= k)
            {
                memory[r, c, k] = 0; return 0;
            }

            if (k == 0)
            {
                memory[r, c, k] = 1; return 1;
            }
            else
            {
                int cnt = 0;
                for (int _r = rcnt - 1; _r > r; _r--)  // 横着切1刀
                {
                    if (pre[_r, ccnt] - pre[r, ccnt] - pre[_r, c] + pre[r, c] <= 0) break;
                    cnt += dfs(pizza, _r, c, k - 1, pre, memory); cnt %= MOD;
                }
                for (int _c = ccnt - 1; _c > c; _c--)  // 竖着切1刀
                {
                    if (pre[rcnt, _c] - pre[r, _c] - pre[rcnt, c] + pre[r, c] <= 0) break;
                    cnt += dfs(pizza, r, _c, k - 1, pre, memory); cnt %= MOD;
                }

                memory[r, c, k] = cnt;
            }

            return memory[r, c, k];
        }
    }
}
