using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0017
{
    public class Solution0017 : Interface0017
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            if (s.Length < t.Length) return "";

            int[] freq = new int['z' - 'A' + 1], _freq = new int['z' - 'A' + 1];
            int len = t.Length, cnt = 0;
            for (int i = 0; i < len; i++) if (++freq[t[i] - 'A'] == 1) cnt++;
            len = s.Length;

            int span = len + 1, left = -1, right = len + 1;
            int pl = 0, pr = -1, idx;
            while (pr < len)
            {
                while (++pr < len)
                {
                    if (++_freq[idx = s[pr] - 'A'] == freq[idx]) cnt--;
                    if (cnt == 0) break;
                }
                if (pr == len) break;
                while (pl <= pr)
                {
                    if (_freq[idx = s[pl] - 'A'] == freq[idx]) break;
                    _freq[idx]--;
                    pl++;
                }

                if (pr - pl < span)
                {
                    span = pr - pl; left = pl; right = pr;
                }
            }

            return span == len + 1 ? "" : s[left..(right + 1)];
        }
    }
}
