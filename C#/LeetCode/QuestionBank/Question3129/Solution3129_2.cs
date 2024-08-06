using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3129
{
    public class Solution3129_2 : Interface3129
    {
        /// <summary>
        /// DFS + 记搜
        /// 逻辑同Solution3129，增加了记忆化搜索来加速计算过程
        /// 
        /// 相比Solution3129快了很多，但是依然TLE，参考测试用例06
        /// 单独跑测试用例06并不慢，LC上也可以通过，但是LC上提交TLE，猜测LC有所有测试用例总用时的限制
        /// </summary>
        /// <param name="zero"></param>
        /// <param name="one"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            const int MOD = (int)1e9 + 7;
            Dictionary<(bool is_zero, int cnt, int zero_cnt, int one_cnt), int> memory = new Dictionary<(bool is_zero, int cnt, int zero_cnt, int one_cnt), int>();

            return dfs(true, 0, zero, one);

            int dfs(bool is_zero, int cnt, int zero_cnt, int one_cnt)
            {
                if (memory.ContainsKey((is_zero, cnt, zero_cnt, one_cnt))) return memory[(is_zero, cnt, zero_cnt, one_cnt)];
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
                memory.Add((is_zero, cnt, zero_cnt, one_cnt), result);

                return result;
            }
        }
    }
}
