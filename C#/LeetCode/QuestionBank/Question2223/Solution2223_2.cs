using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2223
{
    public class Solution2223_2 : Interface2223
    {
        /// <summary>
        /// 字符串Hash + 类前缀和 + 二分
        /// 
        /// 逻辑与Solution2223完全相同，但是Solution2223提交会TLE，这里改用两个MOD并移除防哈希碰撞的验证部分，生产中慎用，还是用扩展KMP吧
        /// 提交竟然能通过了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long SumScores(string s)
        {
            int len = s.Length;
            if (len == 1) return 1;
            if (len == 2) return s[0] == s[1] ? 3 : 2;

            const int MOD1 = (int)1e9 + 7, MOD2 = (int)1e9 + 9, BASE = 31, ORI = '`';
            long[] hashs1 = new long[len + 1], hashs2 = new long[len + 1], bases1 = new long[len + 1], bases2 = new long[len + 1];
            bases1[0] = bases2[0] = 1;
            int[] dists = new int[27];
            for (int i = 0; i < len; i++)
            {
                hashs1[i + 1] = (hashs1[i] * BASE + s[i] - ORI) % MOD1;
                hashs2[i + 1] = (hashs2[i] * BASE + s[i] - ORI) % MOD2;
                bases1[i + 1] = bases1[i] * BASE % MOD1;
                bases2[i + 1] = bases2[i] * BASE % MOD2;
                dists[s[i] - ORI]++;
            }
            int cnt = 0;
            for (int i = 0; i < 26; i++) if (dists[i] > 0) cnt++;
            if (cnt == 1) return 1L * len * (len + 1) >> 1;

            long result = len;
            int left, right, mid, maxidx;
            for (int i = 1; i < len; i++) if (s[i] == s[0])
                {
                    left = 0; right = len - i - 1; maxidx = 0;
                    while (left <= right)
                    {
                        mid = left + ((right - left) >> 1);
                        if ((hashs1[i + mid + 1] - hashs1[i] * bases1[mid + 1] % MOD1 + MOD1) % MOD1 == hashs1[mid + 1] &&
                            (hashs2[i + mid + 1] - hashs2[i] * bases2[mid + 1] % MOD2 + MOD2) % MOD2 == hashs2[mid + 1])
                        {
                            maxidx = mid; left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    result += maxidx + 1;
                }

            return result;
        }

        /// <summary>
        /// 逻辑完全同SumScores()，试一下一个MOD
        /// ... ...提交也通过了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long SumScores2(string s)
        {
            int len = s.Length;
            if (len == 1) return 1;
            if (len == 2) return s[0] == s[1] ? 3 : 2;

            const int MOD = (int)1e9 + 7, BASE = 31, ORI = '`';
            long[] hashs = new long[len + 1], bases = new long[len + 1];
            bases[0] = 1;
            int[] dists = new int[27];
            for (int i = 0; i < len; i++)
            {
                hashs[i + 1] = (hashs[i] * BASE + s[i] - ORI) % MOD;
                bases[i + 1] = bases[i] * BASE % MOD;
                dists[s[i] - ORI]++;
            }
            int cnt = 0;
            for (int i = 0; i < 26; i++) if (dists[i] > 0) cnt++;
            if (cnt == 1) return 1L * len * (len + 1) >> 1;

            long result = len;
            int left, right, mid, maxidx;
            for (int i = 1; i < len; i++) if (s[i] == s[0])
                {
                    left = 0; right = len - i - 1; maxidx = 0;
                    while (left <= right)
                    {
                        mid = left + ((right - left) >> 1);
                        if ((hashs[i + mid + 1] - hashs[i] * bases[mid + 1] % MOD + MOD) % MOD == hashs[mid + 1])
                        {
                            maxidx = mid; left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    result += maxidx + 1;
                }

            return result;
        }
    }
}
