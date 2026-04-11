using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1297
{
    public class Solution1297_2 : Interface1297
    {
        /// <summary>
        /// 多轮滑动窗口
        /// 逻辑同Solution1297
        /// </summary>
        /// <param name="s"></param>
        /// <param name="maxLetters"></param>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public int MaxFreq2(string s, int maxLetters, int minSize, int maxSize)
        {
            int len = s.Length;
            if (maxLetters >= 26) return ((len << 1) - minSize - maxSize + 2) * (maxSize - minSize + 1) >> 1;

            int result = 0, cnt, p1 = -1, p2;
            int[] cnts = new int[26];
            Dictionary<string, int> map = new Dictionary<string, int>();
            string sub;
            for (int size = minSize; size <= maxSize; size++)
            {
                Array.Fill(cnts, 0); p1 = 0; cnt = 0;
                for (p2 = 0; p2 < size - 1; p2++) if (++cnts[s[p2] - 'a'] == 1) cnt++;
                while (p2 < len)
                {
                    if (++cnts[s[p2] - 'a'] == 1) cnt++;
                    if (cnt <= maxLetters)
                    {
                        sub = s[p1..(p2 + 1)];
                        if (map.TryGetValue(sub, out int val)) map[sub] = ++val; else map.Add(sub, 1);
                    }
                    if (--cnts[s[p1++] - 'a'] == 0) cnt--;
                    p2++;
                }

                foreach (int val in map.Values) result = Math.Max(result, val);
                map.Clear();
            }

            return result;
        }

        /// <summary>
        /// 逻辑同MaxFreq()，稍加优化
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

            int result = 0, _cnt = 0, cnt, p1 = -1, p2;
            int[] _cnts = new int[26], cnts = new int[26];
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

            for (int i = 0; i < minSize - 2; i++) if (++_cnts[s[i] - 'a'] == 1) _cnt++;
            for (int size = minSize; size <= maxSize && len - size + 1 > result; size++)
            {
                if (++_cnts[s[size - 2] - 'a'] == 1) _cnt++;
                Array.Copy(_cnts, cnts, 26); p1 = 0; cnt = _cnt;
                p2 = size - 2;
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
                map.Clear();
            }

            return result;
        }
    }
}
