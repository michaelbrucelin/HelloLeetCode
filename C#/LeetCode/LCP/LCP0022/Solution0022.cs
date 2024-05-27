using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0022
{
    public class Solution0022 : Interface0022
    {
        /// <summary>
        /// 分类统计
        /// 1. 0个竖的，全是横的
        /// 2. 1个竖的，剩下全是横的
        /// 3. 2个竖的，剩下全是横的
        /// ... ... 要保证横的比竖的多，然后直接乘以2，就是竖的比横的多的结果（对称的）
        /// 最后计算横的等于竖的的结果
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int PaintingPlan(int n, int k)
        {
            if (k == 0 || k == n * n) return 1;  // 题目限定 k：[0, n*n]

            int result = 0, rcnt = k / n + 1, ccnt = 0;
            while (--rcnt > 0)
            {
                ccnt = (k - rcnt * n) / (n - rcnt);
                if (rcnt <= ccnt) break;
                if ((rcnt + ccnt) * n - rcnt * ccnt == k)
                {
                    result += Combination(n, rcnt) * Combination(n, ccnt);
                }
            }
            result <<= 1;
            if (rcnt == ccnt && (rcnt + ccnt) * n - rcnt * ccnt == k)
                result += Combination(n, rcnt) * Combination(n, ccnt);

            return result;
        }

        private int Combination(int m, int n)
        {
            int result = 1;
            for (int i = 0; i < n; i++) result *= m - i;
            for (int i = 2; i <= n; i++) result /= i;

            return result;
        }
    }
}
