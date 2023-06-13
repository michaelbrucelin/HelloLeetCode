using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1816
{
    public class Solution1816 : Interface1816
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string TruncateSentence(string s, int k)
        {
            int cnt = 0, i;
            for (i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (++cnt == k) break;
                }
            }

            return s.Substring(0, i);
        }
    }
}
