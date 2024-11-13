using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3261
{
    public class Solution3261_2 : Interface3261
    {
        /// <summary>
        /// 逻辑同Solution3261，但是预先记录下以s[i]为起点的满足K约束的最长子字符串的长度，避免大量的重复运算
        /// TestCase03的运行时间由 00:04:52.7399579 降为 00:00:56.3876092，依旧TLE
        /// 慢在每一次查询上，所以要从这个地方想办法优化
        ///     for (int i = 0; i < len; i++) for (int j = queries[i][0], J = queries[i][1]; j <= queries[i][1]; j++)
        ///         {
        ///             result[i] += Math.Min(memory[j], J) - j + 1;
        ///         }
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public long[] CountKConstraintSubstrings(string s, int k, int[][] queries)
        {
            int[] memory = _MaxKConstraintSubstring();

            int len = queries.Length;
            long[] result = new long[len];
            for (int i = 0; i < len; i++) for (int j = queries[i][0], J = queries[i][1]; j <= queries[i][1]; j++)
                {
                    result[i] += Math.Min(memory[j], J) - j + 1;
                }

            return result;

            int[] _MaxKConstraintSubstring()
            {
                int len = s.Length, p1 = 0, p2 = -1, cnt0 = 0, cnt1 = 0;
                int[] result = new int[len];
                while (p1 < len)
                {
                    while (p2 + 1 < len && ((cnt0 + 1 - (s[p2 + 1] & 15)) <= k || (cnt1 + (s[p2 + 1] & 15)) <= k))
                    {
                        p2++; cnt0 += 1 - (s[p2] & 15); cnt1 += s[p2] & 15;
                    }
                    result[p1] = p2;

                    cnt0 -= 1 - (s[p1] & 15); cnt1 -= s[p1] & 15; p1++;
                }

                return result;
            }
        }
    }
}
