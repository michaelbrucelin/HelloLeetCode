using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1717
{
    public class Solution1717_err : Interface1717
    {
        /// <summary>
        /// 贪心
        /// 
        /// 删除一部分字串后会形成新的ab或ba，可以继续删除，这里忽略了这个，所以思路一开始就完全是错误的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MaximumGain(string s, int x, int y)
        {
            int result = 0, len = s.Length;
            if (x == y)
            {
                for (int i = 1; i < len; i++) if ((s[i] == 'a' || s[i] == 'b') && (s[i - 1] + s[i]) == 195)
                    {
                        result += x;
                        i++;
                    }
            }
            else  // 找出a b连续交错的子串，分两种情况讨论
            {
                int pl = 0, pr, _len;
                while (pl < len)
                {
                    while (pl < len && s[pl] != 'a' && s[pl] != 'b') pl++;
                    if (pl == len) break;
                    pr = pl;
                    while (pr + 1 < len && s[pr] + s[pr + 1] == 195) pr++;
                    _len = pr - pl + 1;
                    if (s[pl] == 'a')
                    {
                        result += Math.Max((_len >> 1) * x, ((_len - 1) >> 1) * y);
                    }
                    else
                    {
                        result += Math.Max((_len >> 1) * y, ((_len - 1) >> 1) * x);
                    }
                    pl = pr + 1;
                }
            }

            return result;
        }
    }
}
