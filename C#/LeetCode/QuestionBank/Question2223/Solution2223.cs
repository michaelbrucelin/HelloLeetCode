using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2223
{
    public class Solution2223 : Interface2223
    {
        /// <summary>
        /// 字符串Hash + 类前缀和 + 二分
        /// 
        /// 逻辑没问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long SumScores(string s)
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
                        if ((hashs[i + mid + 1] - hashs[i] * bases[mid + 1] % MOD + MOD) % MOD == hashs[mid + 1] && CheckHashCollision(0, i, mid + 1))
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

            bool CheckHashCollision(int pl, int pr, int len)
            {
                // 第一个字符在主函数中验证过了
                for (int i = 1; i < len; i++) if (s[pl + i] != s[pr + i]) return false;
                return true;
            }
        }
    }
}
