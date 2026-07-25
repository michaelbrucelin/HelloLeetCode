using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3163
{
    public class Solution3163 : Interface3163
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string CompressedString(string word)
        {
            StringBuilder result = new StringBuilder();
            char prev = word[0];
            int cnt = 1, id = 0, len = word.Length;
            while (++id < len)
            {
                if (word[id] != prev)
                {
                    while (cnt > 9) { result.Append(9); result.Append(prev); cnt -= 9; }
                    result.Append(cnt); result.Append(prev);
                    prev = word[id]; cnt = 1;
                }
                else
                {
                    cnt++;
                }
            }
            while (cnt > 9) { result.Append(9); result.Append(prev); cnt -= 9; }
            result.Append(cnt); result.Append(prev);

            return result.ToString();
        }
    }
}
