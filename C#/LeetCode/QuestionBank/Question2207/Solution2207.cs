using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2207
{
    public class Solution2207 : Interface2207
    {
        /// <summary>
        /// 贪心
        /// 插入到最前，或插入到最后，注意pattern两个字符一样的特殊情况
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public long MaximumSubsequenceCount(string text, string pattern)
        {
            long result = 0;
            if (pattern[0] == pattern[1])
            {
                long cnt = text.Count(x => x == pattern[0]);
                result = (cnt * (cnt + 1)) >> 1;
            }
            else
            {
                int[] freq = new int[2];
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == pattern[0])
                    {
                        freq[0]++;
                    }
                    else if (text[i] == pattern[1])
                    {
                        result += freq[0]; freq[1]++;
                    }
                }
                result += Math.Max(freq[0], freq[1]);
            }

            return result;
        }
    }
}
