using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3106
{
    public class Solution3106 : Interface3106
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetSmallestString(string s, int k)
        {
            if (k == 0) return s;

            char[] chars = s.ToCharArray();
            int dist, len = chars.Length;
            for (int i = 0; i < len; i++) if (k > 0 && chars[i] != 'a')
                {
                    dist = Math.Min(chars[i] - 'a', 'a' + 26 - chars[i]);
                    if (dist <= k)
                    {
                        chars[i] = 'a'; k -= dist;
                    }
                    else
                    {
                        chars[i] = (char)(chars[i] - k); break;
                    }
                }

            return new string(chars);
        }
    }
}
