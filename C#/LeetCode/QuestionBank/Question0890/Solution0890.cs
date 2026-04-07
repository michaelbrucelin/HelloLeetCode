using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0890
{
    public class Solution0890 : Interface0890
    {
        /// <summary>
        /// 构造
        /// 构造p[x]即可
        /// </summary>
        /// <param name="words"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            List<string> result = [];
            char[] p1 = new char[26], p2 = new char[26];
            int idx1, idx2, len = pattern.Length;
            foreach (string word in words) if (word.Length == len)
                {
                    Array.Fill(p1, '\0'); Array.Fill(p2, '\0');
                    for (int i = 0; i < len; i++)
                    {
                        idx1 = pattern[i] - 'a'; idx2 = word[i] - 'a';
                        if (p1[idx1] == '\0' && p2[idx2] == '\0')
                        {
                            p1[idx1] = word[i]; p2[idx2] = pattern[i];
                        }
                        else if (p1[idx1] == '\0' || p2[idx2] == '\0')
                        {
                            goto CONTINUE;
                        }
                        else if (p1[idx1] != word[i] || p2[idx2] != pattern[i])
                        {
                            goto CONTINUE;
                        }
                    }
                    result.Add(word);
                CONTINUE:;
                }

            return result;
        }
    }
}
