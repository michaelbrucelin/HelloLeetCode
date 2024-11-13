using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3261
{
    public class Solution3261 : Interface3261
    {
        /// <summary>
        /// 使用Solution3258的逻辑试一下
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public long[] CountKConstraintSubstrings(string s, int k, int[][] queries)
        {
            int len = queries.Length;
            long[] result = new long[len];
            for (int i = 0; i < len; i++) result[i] = _CountKConstraintSubstrings(queries[i]);

            return result;

            long _CountKConstraintSubstrings(int[] query)
            {
                long result = 0;
                int len = query[1] + 1, p1 = query[0], p2 = query[0] - 1, cnt0 = 0, cnt1 = 0;
                while (p1 < len)
                {
                    while (p2 + 1 < len && ((cnt0 + 1 - (s[p2 + 1] & 15)) <= k || (cnt1 + (s[p2 + 1] & 15)) <= k))
                    {
                        p2++; cnt0 += 1 - (s[p2] & 15); cnt1 += s[p2] & 15;
                    }
                    result += p2 - p1 + 1;

                    cnt0 -= 1 - (s[p1] & 15); cnt1 -= s[p1] & 15; p1++;
                }

                return result;
            }
        }
    }
}
