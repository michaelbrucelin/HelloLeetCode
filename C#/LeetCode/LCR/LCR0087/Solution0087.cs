using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0087
{
    public class Solution0087 : Interface0087
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            if (s.Length < 4 || s.Length > 12) return [];

            List<string> result = [];
            int len = s.Length;
            char[] buffer = new char[len + 4];
            backtrack(0, 4, 0);

            return result;

            void backtrack(int idx, int cnt, int pos)
            {
                if (len - idx < cnt || len - idx > cnt * 3) return;
                if (cnt == 0)
                {
                    if (idx == len) result.Add(new string(buffer, 0, len + 3));
                    return;
                }
                for (int i = 1; i < 4 && idx + i - 1 < len; i++) if (i == 1 || (s[idx] != '0' && int.Parse(s.AsSpan(idx, i)) <= 255))
                    {
                        for (int j = 0; j < i; j++) buffer[pos + j] = s[idx + j]; buffer[pos + i] = '.';
                        backtrack(idx + i, cnt - 1, pos + i + 1);
                    }
            }
        }
    }
}
