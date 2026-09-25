using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3039
{
    public class Solution3039 : Interface3039
    {
        /// <summary>
        /// 计数
        /// 最后一轮删除的就是数量最多的字符的最后一个
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LastNonEmptyString(string s)
        {
            int len = s.Length;
            int[] cnts = new int[26];
            for (int i = 0; i < len; i++) cnts[s[i] - 'a']++;
            int max = 0;
            HashSet<char> set = [];
            for (int i = 0; i < 26; i++) max = Math.Max(max, cnts[i]);
            for (int i = 0; i < 26; i++) if (cnts[i] == max) set.Add((char)('a' + i));

            char[] result = new char[set.Count];
            int idx = result.Length - 1;
            for (int i = len - 1; i >= 0 && idx >= 0; i--) if (set.Contains(s[i]))
                {
                    result[idx--] = s[i]; set.Remove(s[i]);
                }

            return new string(result);
        }
    }
}
