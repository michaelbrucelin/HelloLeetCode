using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2002
{
    public class Solution2002 : Interface2002
    {
        /// <summary>
        /// 二进制枚举 + DP
        /// 二进制枚举将s分为两个不相交的子序列，然后DP在每个子序列中找最长的回文子序列
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxProduct(string s)
        {
            if (s.Length == 2) return 1;

            int result = 0, MASK = 1 << s.Length;
            List<char>[] lists = [[], []];
            for (int mask = 1, _mask, _id; mask < MASK; mask++)
            {
                lists[0].Clear(); lists[1].Clear();
                _mask = mask; _id = 0;
                while (_mask > 0)
                {
                    lists[_mask & 1].Add(s[_id]);
                    _mask >>= 1; _id++;
                }
                result = Math.Max(result, dp(lists[0]) * dp(lists[1]));
            }

            return result;

            static int dp(List<char> list)
            {
                if (list.Count < 2) return list.Count;

                int cnt = list.Count;
                int[,] dp = new int[cnt, cnt];
                for (int i = 0; i < cnt; i++) dp[i, i] = 1;
                for (int span = 1; span < cnt; span++) for (int i = 0, j = span; j < cnt; i++, j++)
                    {
                        if (list[i] == list[j])
                        {
                            dp[i, j] = dp[i + 1, j - 1] + 2;
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                        }
                    }

                return dp[0, cnt - 1];
            }
        }
    }
}
