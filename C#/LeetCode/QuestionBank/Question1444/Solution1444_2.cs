using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1444
{
    public class Solution1444_2 : Interface1444
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// DP
        /// 逻辑同Solution1444的DP，只是1:1改为了DP而已
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

            int[,,] memory = new int[rcnt + 1, ccnt + 1, k]; int cnt;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (pre[rcnt, ccnt] - pre[r, ccnt] - pre[rcnt, c] + pre[r, c] > 0) memory[r, c, 0] = 1;
                }
            for (int r = rcnt - 1; r >= 0; r--) for (int c = ccnt - 1; c >= 0; c--) for (int i = 1; i < k; i++)
                    {
                        if (pre[rcnt, ccnt] - pre[r, ccnt] - pre[rcnt, c] + pre[r, c] <= i) break;
                        cnt = 0;
                        for (int _r = rcnt - 1; _r > r; _r--)
                        {
                            if (pre[_r, ccnt] - pre[r, ccnt] - pre[_r, c] + pre[r, c] <= 0) break;
                            cnt += memory[_r, c, i - 1]; cnt %= MOD;
                        }
                        for (int _c = ccnt - 1; _c > c; _c--)
                        {
                            if (pre[rcnt, _c] - pre[r, _c] - pre[rcnt, c] + pre[r, c] <= 0) break;
                            cnt += memory[r, _c, i - 1]; cnt %= MOD;
                        }
                        memory[r, c, i] = cnt;
                    }

            return memory[0, 0, k - 1];
        }
    }
}
