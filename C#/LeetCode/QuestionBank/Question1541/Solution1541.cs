using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1541
{
    public class Solution1541 : Interface1541
    {
        /// <summary>
        /// 遍历
        /// 与普通的括号处理逻辑一致，只需要提前将 )) "替换" 为 ")" 即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinInsertions(string s)
        {
            int result = 0, len = s.Length;
            List<char> chars = [];
            int id = -1;
            while (++id < len) switch (s[id])
                {
                    case '(': chars.Add('('); break;
                    case ')':
                        if (id + 1 < len && s[id + 1] == ')') id++; else result++;
                        chars.Add(')');
                        break;
                    default: break;
                }

            int lcnt = 0;
            foreach (char c in chars) switch (c)
                {
                    case '(': lcnt++; break;
                    case ')': if (lcnt > 0) lcnt--; else result++; break;
                    default: break;
                }
            result += lcnt << 1;

            return result;
        }

        /// <summary>
        /// 逻辑与MinInsertions()完全一致，移除了中间的缓存
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinInsertions2(string s)
        {
            int result = 0, lcnt = 0, len = s.Length;
            int id = -1;
            while (++id < len) switch (s[id])
                {
                    case '(': lcnt++; break;
                    case ')':
                        if (id + 1 < len && s[id + 1] == ')') id++; else result++;
                        if (lcnt > 0) lcnt--; else result++;
                        break;
                    default: break;
                }
            result += lcnt << 1;

            return result;
        }
    }
}
