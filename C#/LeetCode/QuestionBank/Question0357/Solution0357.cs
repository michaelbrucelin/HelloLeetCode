using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0357
{
    public class Solution0357 : Interface0357
    {
        /// <summary>
        /// 数位DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountNumbersWithUniqueDigits(int n)
        {
            if (n == 0) return 1;

            int MASK = 1024;
            int[,,] memory = new int[n, MASK, 2];
            for (int i = 0; i < n; i++) for (int j = 0; j < MASK; j++) memory[i, j, 0] = memory[i, j, 1] = -1;
            return dfs(0, 0, true);

            int dfs(int idx, int mask, bool is_zero)
            {
                if (idx == n) return 1;
                int _is_zero = is_zero ? 1 : 0;
                if (memory[idx, mask, _is_zero] != -1) return memory[idx, mask, _is_zero];

                int result = 0;
                if (is_zero) result += dfs(idx + 1, mask, is_zero);
                int low = is_zero ? 1 : 0;
                for (int i = low; i < 10; i++) if (((mask >> i) & 1) != 1)
                    {
                        result += dfs(idx + 1, mask | (1 << i), false);
                    }
                memory[idx, mask, _is_zero] = result;

                return result;
            }
        }
    }
}
