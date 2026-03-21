using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0076
{
    public class Solution0076 : Interface0076
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            int[] cnts = new int[52], cntt = new int[52];
            foreach (char c in t) cntt[getidx(c)]++;
            int rl = -1, rr = s.Length, pl = 0, pr = -1, idx = 0, cnt = 0, _cnt = 0, len = s.Length;
            for (int i = 0; i < 52; i++) if (cntt[i] > 0) cnt++;
            // string result = new string('\0', len + 1);  // 改为使用rl与rr做哨兵，return result.Length > len ? "" : result;
            while (pr < len)
            {
                while (++pr < len)
                {
                    if (cntt[idx = getidx(s[pr])] == 0) continue;
                    if (++cnts[idx] == cntt[idx]) _cnt++;
                    if (_cnt == cnt) break;
                }
                if (pr == len) break;
                while (pl < len)
                {
                    if (cntt[idx = getidx(s[pl])] > 0 && cnts[idx] == cntt[idx]) break;
                    cnts[idx]--;
                    pl++;
                }
                if (pr - pl < rr - rl) (rl, rr) = (pl, pr);

                cnts[idx]--; _cnt--;
                pl++;
            }

            return rl == -1 ? "" : s[rl..(rr + 1)];

            static int getidx(char c)
            {
                return (c & 31) - 1 + ((c >> 5) & 1) * 26;
            }
        }
    }
}
