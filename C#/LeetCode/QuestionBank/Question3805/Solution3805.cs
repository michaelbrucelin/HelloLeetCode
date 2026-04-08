using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3805
{
    public class Solution3805 : Interface3805
    {
        /// <summary>
        /// Hash
        /// 直接将字符串的首字母置换为a，然后依次置换后面的字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public long CountPairs(string[] words)
        {
            long result = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();
            int offset, len = words[0].Length; string s;
            char[] buffer = new char[len];
            foreach (string word in words)
            {
                if (word[0] != 'a')
                {
                    offset = 'a' + 26 - word[0];
                    for (int i = 0; i < len; i++) buffer[i] = (char)((word[i] - 'a' + offset) % 26 + 'a');
                    s = new string(buffer);
                }
                else
                {
                    s = word;
                }

                if (map.TryGetValue(s, out int val))
                {
                    result += val; map[s] = ++val;
                }
                else
                {
                    map.Add(s, 1);
                }
            }

            return result;
        }
    }
}
