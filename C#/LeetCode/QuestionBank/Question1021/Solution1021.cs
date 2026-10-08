using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1021
{
    public class Solution1021 : Interface1021
    {
        /// <summary>
        /// 分析
        /// 从左向右遍历字符串，每当左右括号数量相等时，就是一个“原语”
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveOuterParentheses(string s)
        {
            StringBuilder result = new StringBuilder();
            int pl = 0, pr = -1, cnt = 0, len = s.Length;
            while (pl < len) while (++pr < len)
                {
                    cnt += ((s[pr] & 1) << 1) - 1;  // (: -1, ): 1
                    if (cnt == 0)
                    {
                        // result.Append(s.Substring(pl + 1, pr - pl - 1));
                        // result.Append(s[(pl + 1)..pr]);
                        // result.Append(s.AsSpan(pl + 1, pr - pl - 1));
                        result.Append(s, pl + 1, pr - pl - 1);
                        pl = pr + 1;
                        break;
                    }
                }

            return result.ToString();
        }
    }
}
