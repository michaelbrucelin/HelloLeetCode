using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1297
{
    public class Solution1297_3 : Interface1297
    {
        /// <summary>
        /// 脑筋急转弯
        /// 逻辑同Solution1297_2，但是有一个重大的问题，就是maxSize没有用，只找minSize就完事了，思维定势了...
        /// </summary>
        /// <param name="s"></param>
        /// <param name="maxLetters"></param>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
        {
            int len = s.Length;
            if (maxLetters >= 26) return ((len << 1) - minSize - maxSize + 2) * (maxSize - minSize + 1) >> 1;

            int result = 0, cnt = 0, p1, p2;
            int[] cnts = new int[26];
            Dictionary<string, int> map = new Dictionary<string, int>();

            if (minSize == 1)
            {
                for (int i = 0; i < len; i++) cnts[s[i] - 'a']++;
                return cnts.Max();
            }

            string sub;
            if (maxLetters >= minSize)
            {
                for (p1 = 0, p2 = minSize - 1; p2 < len; p1++, p2++)
                {
                    sub = s[p1..(p2 + 1)];
                    if (map.TryGetValue(sub, out int val)) map[sub] = ++val; else map.Add(sub, 1);
                }
                return map.Values.Max();
            }

            for (int i = 0; i < minSize - 1; i++) if (++cnts[s[i] - 'a'] == 1) cnt++;
            p1 = 0; p2 = minSize - 2;
            while (++p2 < len)
            {
                if (++cnts[s[p2] - 'a'] == 1) cnt++;
                if (cnt <= maxLetters)
                {
                    sub = s[p1..(p2 + 1)];
                    if (map.TryGetValue(sub, out int val)) map[sub] = ++val; else map.Add(sub, 1);
                }
                if (--cnts[s[p1++] - 'a'] == 0) cnt--;
            }

            foreach (int val in map.Values) result = Math.Max(result, val);
            return result;
        }
    }
}
