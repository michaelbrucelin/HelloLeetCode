using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3753
{
    public class Solution3753_tle : Interface3753
    {
        /// <summary>
        /// 数位DP
        /// 逻辑没错，但是这不是数位DP，本质上仍然是暴力解，所以TLE，参考测试用例04
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public long TotalWaviness(long num1, long num2)
        {
            List<int> digits = [];
            long result1 = 0, result2 = 0;
            get_digits(num1 - 1);
            dfs(0, -1, -1, 0, true, 0, ref result1);
            get_digits(num2);
            dfs(0, -1, -1, 0, true, 0, ref result2);

            return result2 - result1;

            void dfs(int idx, int pre1, int pre2, int len, bool is_prefix, int cnt, ref long result)  // pre1, pre2 前面两个数字
            {
                if (idx == digits.Count) { result += cnt; return; }

                int upper = is_prefix ? digits[idx] : 9;
                for (int i = 0; i <= upper; i++)
                {
                    if ((pre1 - pre2) * (i - pre2) > 0 && len >= 2)
                        dfs(idx + 1, pre2, i, (i != 0 || len > 0) ? len + 1 : 0, is_prefix && i == digits[idx], cnt + 1, ref result);
                    else
                        dfs(idx + 1, pre2, i, (i != 0 || len > 0) ? len + 1 : 0, is_prefix && i == digits[idx], cnt, ref result);
                }
            }

            void get_digits(long x)
            {
                digits.Clear();
                while (x > 0) { digits.Add((int)(x % 10)); x /= 10; }
                digits.Reverse();
            }
        }
    }
}
