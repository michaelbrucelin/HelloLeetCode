using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3261
{
    public class Solution3261_3 : Interface3261
    {
        /// <summary>
        /// 逻辑同Solution3261_2，略加优化，直接上依然会TLE，先写出来看看
        /// TestCase03的运行时间由 00:00:56.3876092 降为 00:00:36.1203239，依旧TLE
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
            for (int i = 0, j = 0, J = 0; i < len; i++)
            {
                for (j = queries[i][0], J = queries[i][1]; j <= queries[i][1]; j++)
                {
                    if (memory[j] < J) result[i] += memory[j] - j + 1; else break;
                }
                result[i] += (J - j + 1) * (J - j + 2) / 2;
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