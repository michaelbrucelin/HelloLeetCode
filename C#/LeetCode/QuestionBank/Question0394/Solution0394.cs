using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0394
{
    public class Solution0394 : Interface0394
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString(string s)
        {
            return dv(0, s.Length - 1);

            string dv(int l, int r)
            {
                StringBuilder result = new StringBuilder();

                int p = l, _l, _r;
                while (p <= r)
                {
                    if (char.IsAsciiDigit(s[p]))
                    {
                        int time = s[p] & 15, lcnt = 1;
                        while (char.IsAsciiDigit(s[++p])) time = time * 10 + (s[p] & 15);
                        _l = p + 1;
                        while (lcnt != 0) { if (s[++p] == '[') lcnt++; else if (s[p] == ']') lcnt--; }
                        _r = p - 1;
                        string s_dv = dv(_l, _r);
                        for (int i = 0; i < time; i++) result.Append(s_dv);
                        p++;
                    }
                    else  // if (char.IsAsciiLetterLower(s[p]))
                    {
                        _l = p;
                        while (++p <= r && char.IsAsciiLetterLower(s[p])) ;
                        result.Append(s[_l..p]);
                    }
                }

                return result.ToString();
            }
        }
    }
}
