using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1711
{
    public class Solution1711 : Interface1711
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int FindClosest(string[] words, string word1, string word2)
        {
            int result = words.Length, idx1 = -1, idx2 = -1, len = words.Length;  // 验证过，如果wors1与word2不同时存在，结果是数组长度
            for (int i = 0; i < len; i++)
            {
                if (words[i] == word1)
                {
                    idx1 = i;
                    if (idx2 != -1) result = Math.Min(result, idx1 - idx2);
                }
                else if (words[i] == word2)
                {
                    idx2 = i;
                    if (idx1 != -1) result = Math.Min(result, idx2 - idx1);
                }
            }

            return result;
        }
    }
}
