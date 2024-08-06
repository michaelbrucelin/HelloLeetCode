using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3129
{
    public class Solution3129 : Interface3129
    {
        /// <summary>
        /// DFS
        /// 逻辑没问题，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="zero"></param>
        /// <param name="one"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            const int MOD = (int)1e9 + 7;
            return dfs(true, 0, zero, one);

            int dfs(bool is_zero, int cnt, int zero_cnt, int one_cnt)
            {
                if (zero_cnt == 0 && one_cnt == 0) return 1;

                int result = 0;
                if (is_zero)
                {
                    if (cnt < limit && zero_cnt > 0)
                    {
                        result += dfs(true, cnt + 1, zero_cnt - 1, one_cnt);
                        result %= MOD;
                    }
                    if (one_cnt > 0)
                    {
                        result += dfs(false, 1, zero_cnt, one_cnt - 1);
                        result %= MOD;
                    }
                }
                else
                {
                    if (cnt < limit && one_cnt > 0)
                    {
                        result += dfs(false, cnt + 1, zero_cnt, one_cnt - 1);
                        result %= MOD;
                    }
                    if (zero_cnt > 0)
                    {
                        result += dfs(true, 1, zero_cnt - 1, one_cnt);
                        result %= MOD;
                    }
                }

                return result;
            }
        }
    }
}
