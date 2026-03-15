using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0140
{
    public class Solution0140 : Interface0140
    {
        /// <summary>
        /// 哈希 + 回溯
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            List<string> result = [];
            int maxlen = 0, len = s.Length;
            HashSet<string> set = [];
            foreach (string word in wordDict) { set.Add(word); maxlen = Math.Max(maxlen, word.Length); }
            StringBuilder buffer = new();
            backtrack(0, 1);

            return result;

            void backtrack(int l, int r)
            {
                if (r > len || r - l > maxlen) return;

                if (set.Contains(s[l..r]))
                {
                    int backlen = buffer.Length;
                    buffer.Append(s, l, r - l);
                    if (r == len)
                    {
                        result.Add(buffer.ToString());
                    }
                    else
                    {
                        buffer.Append(' ');
                        backtrack(r, r + 1);
                    }
                    buffer.Length = backlen;
                }
                backtrack(l, r + 1);
            }
        }
    }
}
