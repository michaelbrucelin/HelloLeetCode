using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3130
{
    public class Solution3130 : Interface3130
    {
        /// <summary>
        /// 同Solution3129_3
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
