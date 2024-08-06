using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3129
{
    public class Solution3129_3 : Interface3129
    {
        /// <summary>
        /// DFS + 记忆化搜索 + 归并
        /// 1. DFS计算将x个球分为N组（有序的N组）后，每组都不超过limit个球的方案数分布
        ///     即r1组方案数，r2组方案数...，显然，rn 属于 [Ceil(x/limit), x]
        /// 2. 当白球分了m组后，可以匹配m-1组黑球（01010），m组黑球（1010和0101）两次，m+1组黑球（10101）
        /// </summary>
        /// <param name="zero"></param>
        /// <param name="one"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            const int MOD = (int)1e9 + 7;
            Dictionary<int, int[]> memory = new Dictionary<int, int[]>();
            int[] zero_cnts = dfs(zero);
            int[] one_cnts = dfs(one);

            int result = 0, len0 = zero_cnts.Length, len1 = one_cnts.Length;
            long cnt1, cnt2;
            for (int i = 1; i < len0; i++) if ((cnt1 = zero_cnts[i]) > 0)
                {
                    cnt2 = 0;
                    if (i - 1 < len1) cnt2 += one_cnts[i - 1];
                    if (i < len1) cnt2 += one_cnts[i] << 1;
                    if (i + 1 < len1) cnt2 += one_cnts[i + 1];
                    result = (result + (int)(cnt1 * cnt2 % MOD)) % MOD;
                }

            return result;

            int[] dfs(int cnt)
            {
                if (cnt == 0) return [1];
                if (cnt == 1) return [0, 1];
                if (memory.ContainsKey(cnt)) return memory[cnt];

                int[] result = new int[cnt + 1];
                for (int i = 1; i <= Math.Min(cnt, limit); i++)
                {
                    int[] _result = dfs(cnt - i);
                    for (int j = 0; j < _result.Length; j++)
                        result[j + 1] = (result[j + 1] + _result[j]) % MOD;
                }
                memory.Add(cnt, result);

                return result;
            }
        }
    }
}
