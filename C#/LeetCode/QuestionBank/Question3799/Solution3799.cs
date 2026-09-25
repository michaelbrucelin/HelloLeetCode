using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3799
{
    public class Solution3799 : Interface3799
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<string>> WordSquares(string[] words)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Array.Sort(words);
            int len = words.Length;
            for (int t = 0; t < len; t++)
            {
                for (int l = 0; l < len; l++) if (l != t)
                    {
                        for (int r = 0; r < len; r++) if (r != t && r != l)
                            {
                                for (int b = 0; b < len; b++) if (b != t && b != l && b != r)
                                    {
                                        if (words[t][0] == words[l][0] && words[t][3] == words[r][0] &&
                                            words[l][3] == words[b][0] && words[r][3] == words[b][3])
                                            result.Add([words[t], words[l], words[r], words[b]]);
                                    }
                            }
                    }
            }

            return result;
        }
    }
}
