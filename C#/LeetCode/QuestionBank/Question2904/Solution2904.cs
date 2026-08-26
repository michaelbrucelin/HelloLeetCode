using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2904
{
    public class Solution2904 : Interface2904
    {
        public string ShortestBeautifulSubstring(string s, int k)
        {
            int len = s.Length;
            if (len < k) return "";
            if (k == 1)
            {
                for (int i = 0; i < len; i++) if (s[i] == '1') return "1";
                return "";
            }

            int l = 0, r = len, pl = 0, pr, cnt = 1;
            while (pl < len && s[pl] == '0') pl++; pr = pl;
            while (len - pl >= k)
            {
                while (pl < len && s[pl] == '0') pl++;
                if (len - pl < k) break;
                while (cnt < k && ++pr < len)
                {
                    if ((cnt += s[pr] - '0') == k) switch (pr - pl - (r - l))
                        {
                            case < 0: l = pl; r = pr; break;
                            case > 0: break;
                            default: if (isless(s, pl, pr, l, r)) { l = pl; r = pr; } break;
                        }
                }
                pl++; cnt--;
            }

            return r != len ? s[l..(r + 1)] : "";

            static bool isless(string s, int l1, int r1, int l2, int r2)
            {
                for (int i = l1, j = l2; i <= r1; i++, j++) switch (s[i] - s[j])
                    {
                        case < 0: return true;
                        case > 0: return false;
                        default: break;
                    }
                return false;
            }
        }
    }
}
