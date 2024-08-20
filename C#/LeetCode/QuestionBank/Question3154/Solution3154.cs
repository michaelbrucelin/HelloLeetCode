using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3154
{
    public class Solution3154 : Interface3154
    {
        /// <summary>
        /// 数学，组合
        /// 显然，BFS可解，但是时间复杂度会很大，所以需要剪枝
        /// 分析题意，只有两种操作：1. 降一阶，2. 升1, 2, 4 ...阶，所以考虑升降组合即可
        /// 例如，k = 1
        ///     1. 升0次，需要降0次，1种方案
        ///     2. 升1次，需要降1次，考虑到操作顺序，2种方案
        ///     3. 升2次，需要降3次，只有一种顺序，降升降升降，1种方案
        ///     4. 升3次，需要降7次，由于无法连续降，0种方案
        ///     5. 升3次没有方案，升更多次也没有方案
        /// 如果降down次，升up次，显然down <= up + 1次才有解
        ///     首先拿出down - 1次up，插空，排成 d u d u d 型，保证没有连续的 d，然后剩下的up（up-down+1）随便插空
        ///     这时问题就变成将up-down+1个球，分为down+1堆（可以为空堆）的方案数，可以用隔板法解决
        /// 
        /// 这题应该可以打表解决
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int WaysToReachStair(int k)
        {
            if (k == 0) return 2;

            int result = k == 1 ? 1 : 0;
            for (int up = 1, down, reach = 1; ; up++)
            {
                reach += (int)Math.Pow(2, up - 1);
                down = reach - k;
                if (down > 0)
                {
                    if (down > up + 1) break;
                    result += insertboard(up - down + 1, down + 1);
                }
                else if (down == 0)
                {
                    result += 1;
                }
            }

            return result;

            int insertboard(int m, int n)
            {
                int result = 1;
                HashSet<int> set = Enumerable.Range(2, n - 2).ToHashSet();
                for (int i = m + n - 1; i > m; i--)
                {
                    result *= i;
                    foreach (int _n in set) if (result % _n == 0)
                        {
                            result /= _n; set.Remove(_n);
                        }
                }
                return result;
            }
        }

        /// <summary>
        /// 逻辑没问题，同WaysToReachStair()，只是计算阶乘时会溢出
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int WaysToReachStair_overflow(int k)
        {
            if (k == 0) return 2;

            int result = k == 1 ? 1 : 0;
            for (int up = 1, down, reach = 1; ; up++)
            {
                reach += (int)Math.Pow(2, up - 1);
                down = reach - k;
                if (down > 0)
                {
                    if (down > up + 1) break;
                    result += (int)(factorial(up + 1) / factorial(up - down + 1) / factorial(down));
                }
                else if (down == 0)
                {
                    result += 1;
                }
            }

            return result;

            long factorial(long n)
            {
                long result = 1;
                while (n > 1) result *= n--;
                return result;
            }
        }
    }
}
