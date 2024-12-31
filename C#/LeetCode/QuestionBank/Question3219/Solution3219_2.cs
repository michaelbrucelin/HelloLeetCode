using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3219
{
    public class Solution3219_2 : Interface3219
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution3218_3，改为自底向上DP
        /// 1. 计算所有1*1: 1*1
        /// 2. 计算所有2*2: 1*2 --> 2*1 --> 2*2
        /// 3. 计算所有3:3: 1*3 --> 3*1 --> 2*3 --> 3*2 --> 3*3
        /// 4. 计算所有4*4: 1*4 --> 4*1 --> 2*4 --> 4*2 --> 3*4 --> 4*3 --> 4*4
        /// 5. ... ...类九九乘法表
        /// 6. 如果m == n，计算结果，如果m > n，计算 m * n(m > n) 的值，如果m < n 同理
        /// 
        /// 没有提交测试，大概率一样会MLE
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="horizontalCut"></param>
        /// <param name="verticalCut"></param>
        /// <returns></returns>
        public long MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut)
        {
            if (m == 1) return verticalCut.Sum();
            if (n == 1) return horizontalCut.Sum();

            long[,,,] dp = new long[m, m, n, n];
            // for (int r1 = 0; r1 < m; r1++) for (int r2 = 0; r2 < m; r2++) for (int c1 = 0; c1 < n; c1++) for (int c2 = 0; c2 < n; c2++) dp[r1, r2, c1, c2] = -1;  // 无需初始化
            // for (int r = 0; r < m; r++) for (int c = 0; c < n; c++) dp[r, r, c, c] = 0;
            int x;
            for (x = 2; x <= m && x <= n; x++)                                                               // 计算所有 x * x 的值
            {
                for (int r = x - 1; r < m; r++) for (int c = x - 1; c < n; c++)                              // (r,c) 是每一个 x * x 块的右下角的坐标，dp[r-x+1, r, c-x+1, c]
                    {
                        for (int _x = 1; _x < x; _x++)                                                       // 计算所有 1*x x*1 2*x x*2 ... (x_1)*x x*(x-1) 的值
                        {
                            for (int _r = r - x + _x; _r <= r; _r++) DPCost(_r - _x + 1, _r, c - x + 1, c);  // 计算dp[_r-_x+1, _r, c-x+1, c], 1*x 2*x ... (x-1)*x
                            for (int _c = c - x + _x; _c <= c; _c++) DPCost(r - x + 1, r, _c - _x + 1, _c);  // 计算dp[r-x+1, r, _c-_x+1, _c], x*1 x*2 ... x*(x-1)
                        }
                        DPCost(r - x + 1, r, c - x + 1, c);                                                  // 计算dp[r-x+1, r, c-x+1, c]
                    }
            }

            for (int _m = x; _m <= m; _m++)                                                                  // m > n，计算所有 _m * n(m > n) 的值
            {
                for (int r = _m - 1; r < m; r++)                                                             // (r,n-1) 是每一个 _m * n 块的右下角的坐标，dp[r-_m+1, r, 0, n-1]
                {
                    for (int _x = 1; _x <= n; _x++)                                                          // 计算所有 _m*1 _m*2 ... _m*(n-1) 的值
                    {
                        for (int _c = _x - 1; _c < n; _c++) DPCost(r - _m + 1, r, _c - _x + 1, _c);          // 计算dp[r-_m+1, r, _c-_x+1, _c], _m*1 _m*2 ... _m*(n-1)
                    }
                }
            }

            for (int _n = x; _n <= n; _n++)                                                                  // n > m，计算所有 m * _n(n > m) 的值
            {
                for (int c = _n - 1; c < n; c++)                                                             // (m-1,c) 是每一个 m * _n 块的右下角的坐标，dp[0, m-1, c-_n+1, c]
                {
                    for (int _x = 1; _x <= m; _x++)                                                          // 计算所有 1*_n 2*_n ... (n-1)*_n 的值
                    {
                        for (int _r = _x - 1; _r < m; _r++) DPCost(_r - _x + 1, _r, c - _n + 1, c);          // 计算dp[_r-_x+1, _r, c-_n+1, c], 1*_n 2*_n ... (n-1)*_n
                    }
                }
            }

            return dp[0, m - 1, 0, n - 1];

            void DPCost(int r1, int r2, int c1, int c2)
            {
                long cost = long.MaxValue;
                for (int i = r1; i < r2; i++) cost = Math.Min(cost, dp[r1, i, c1, c2] + dp[i + 1, r2, c1, c2] + horizontalCut[i]);
                for (int i = c1; i < c2; i++) cost = Math.Min(cost, dp[r1, r2, c1, i] + dp[r1, r2, i + 1, c2] + verticalCut[i]);
                dp[r1, r2, c1, c2] = cost;
            }
        }
    }
}
