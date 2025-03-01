using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0131
{
    public class Solution0131_err : Interface0131
    {
        /// <summary>
        /// DP，BFS
        /// 假定s[..i]的结果已知，那么s[..i+1]的结果：
        ///     1. s[..i]中的每个结果增加一项s[i+1]，因为s[i+1]必回文
        ///     2. 如果s[..i]结果的最后一项拼接s[i+1]后回文，那么这也是一个结果
        /// 
        /// 思路是错误的，参考："abbab"，错在当由s[..i]到s[..i+1]时，不能只考虑s[i+1]与前面结果的最后一项组个起来是否回文，而是要考虑以s[i+1]结尾的所有回文串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> dp = [new List<string> { s[0..1] }];
            int len = s.Length;
            for (int i = 1, cnt = dp.Count; i < len; i++, cnt = dp.Count) for (int j = 0; j < cnt; j++)
                {
                    if (check(dp[j][^1], i))
                    {
                        List<string> list = [.. dp[j]];  // new List<string>(dp[j])
                        list[^1] = $"{list[^1]}{s[i]}";
                        dp.Add(list);
                    }
                    dp[j].Add(s[i..(i + 1)]);
                }

            return dp;

            bool check(string str, int p)
            {
                if (str[0] != s[p]) return false;
                int l = 1, r = str.Length - 1;
                while (l < r)
                {
                    if (str[l] != str[r]) return false;
                    l++;
                    r--;
                }

                return true;
            }
        }
    }
}
