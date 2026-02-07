using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1620
{
    public class Solution1620 : Interface1620
    {
        /// <summary>
        /// 数组映射
        /// </summary>
        /// <param name="num"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> GetValidT9Words(string num, string[] words)
        {
            char[] map = ['2', '2', '2', '3', '3', '3', '4', '4', '4', '5', '5', '5', '6', '6', '6', '7', '7', '7', '7', '8', '8', '8', '9', '9', '9', '9'];
            List<string> result = new List<string>();
            int n = num.Length;
            foreach (string word in words) if (word.Length == n)
                {
                    for (int i = 0; i < n; i++) if (!char.IsAsciiLetterLower(word[i]) || map[word[i] - 'a'] != num[i]) goto CONTINUE;
                    result.Add(word);
                CONTINUE:;
                }

            return result;
        }
    }
}
