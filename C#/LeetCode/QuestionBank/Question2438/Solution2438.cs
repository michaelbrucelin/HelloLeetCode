using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2438
{
    public class Solution2438 : Interface2438
    {
        /// <summary>
        /// 阅读理解
        /// 最少的2的幂，要求每个元素都是2的幂，而且数目最少。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ProductQueries(int n, int[][] queries)
        {
            List<int> powers = new List<int>();
            while (n > 0) { powers.Add(n - (n & (n - 1))); n -= powers[^1]; }

            const int MOD = (int)1e9 + 7;
            int len = queries.Length;
            int[] result = new int[len];
            long x;
            for (int i = 0; i < len; i++)
            {
                x = 1L;
                for (int j = queries[i][0]; j <= queries[i][1]; j++)
                    x = x * powers[j] % MOD;
                result[i] = (int)x;
            }

            return result;
        }

        /// <summary>
        /// 逻辑与ProductQueries()相同
        /// powers数组中记录不是真实的值，而是幂值，这样可以通过前缀和略加优化
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ProductQueries2(int n, int[][] queries)
        {
            List<int> powers = new List<int>() { 0 };
            int pos = 0;
            while (n > 0)
            {
                if ((n & 1) == 1) powers.Add(pos + powers[^1]);
                n >>= 1;
                pos++;
            }

            const int MOD = (int)1e9 + 7;
            int len = queries.Length;
            int[] result = new int[len];
            long x; int y;
            for (int i = 0; i < len; i++)
            {
                x = 1L;
                y = powers[queries[i][1] + 1] - powers[queries[i][0]];
                while (y > 30) { x = (x * (1 << 30)) % MOD; y -= 30; }
                x = (x * (1 << y)) % MOD;
                result[i] = (int)x;
            }

            return result;
        }
    }
}
