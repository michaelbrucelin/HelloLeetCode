using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2788
{
    public class Solution2788 : Interface2788
    {
        /// <summary>
        /// 类C的朴素解法
        /// </summary>
        /// <param name="words"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
        {
            List<string> result = new List<string>();
            string word; int pl, pr, len;
            for (int i = 0; i < words.Count; i++)
            {
                word = words[i]; len = word.Length; pl = 0;
                while (pl < len)
                {
                    while (pl < len && word[pl] == separator) pl++;
                    if (pl == len) continue;
                    pr = pl; while (pr < len && word[pr] != separator) pr++;
                    result.Add(word[pl..pr]);
                    pl = pr + 1;
                }
            }

            return result;
        }
    }
}
