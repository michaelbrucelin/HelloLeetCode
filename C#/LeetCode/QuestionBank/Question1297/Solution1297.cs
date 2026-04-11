using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1297
{
    public class Solution1297 : Interface1297
    {
        /// <summary>
        /// 双指针
        /// 有太多可以剪枝的地方了
        /// 
        /// ... 直接看Solution1297_3，脑筋急转弯，在Solution1297_2不断优化时才反应过来
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

            int cnt, p1 = -1, p2;
            int[] cnts = new int[26];
            Dictionary<string, int> map = new Dictionary<string, int>();

            if (minSize == 1)
            {
                for (int i = 0; i < len; i++) cnts[s[i] - 'a']++;
                return cnts.Max();
            }

            string sub;
            if (maxLetters >= maxSize)
            {
                for (p1 = 0, p2 = minSize - 1; p2 < len; p1++, p2++)
                {
                    sub = s[p1..(p2 + 1)];
                    if (map.TryGetValue(sub, out int val)) map[sub] = ++val; else map.Add(sub, 1);
                }
                return map.Values.Max();
            }

            while (++p1 < len)
            {
                Array.Fill(cnts, 0); cnt = 0;
                p2 = p1 - 1;
                while (p2 + 1 < len && p2 + 1 - p1 + 1 < minSize)
                {
                    if (++cnts[s[++p2] - 'a'] == 1) { if (++cnt > maxLetters) goto CONTINUE; }
                }
                while (p2 + 1 < len && p2 + 1 - p1 + 1 <= maxSize)
                {
                    if (++cnts[s[++p2] - 'a'] == 1) { if (++cnt > maxLetters) goto CONTINUE; }
                    sub = s[p1..(p2 + 1)];
                    if (map.TryGetValue(sub, out int val)) map[sub] = ++val; else map.Add(sub, 1);
                }
            CONTINUE:;
            }

            int result = 0;
            foreach (int val in map.Values) result = Math.Max(result, val);
            return result;
        }
    }
}
