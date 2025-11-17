using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0423
{
    public class Solution0423 : Interface0423
    {
        static Solution0423()
        {
            info = [('z' - 'a', 0, ['z' - 'a', 'e' - 'a', 'r' - 'a', 'o' - 'a']),
                    ('w' - 'a', 2, ['t' - 'a', 'w' - 'a', 'o' - 'a']),
                    ('u' - 'a', 4, ['f' - 'a', 'o' - 'a', 'u' - 'a', 'r' - 'a']),
                    ('x' - 'a', 6, ['s' - 'a', 'i' - 'a', 'x' - 'a']),
                    ('g' - 'a', 8, ['e' - 'a', 'i' - 'a', 'g' - 'a', 'h' - 'a', 't' - 'a']),
                    ('o' - 'a', 1, ['o' - 'a', 'n' - 'a', 'e' - 'a']),
                    ('t' - 'a', 3, ['t' - 'a', 'h' - 'a', 'r' - 'a', 'e' - 'a', 'e' - 'a']),
                    ('s' - 'a', 7, ['s' - 'a', 'e' - 'a', 'v' - 'a', 'e' - 'a', 'n' - 'a']),
                    ('f' - 'a', 5, ['f' - 'a', 'i' - 'a', 'v' - 'a', 'e' - 'a']),
                    ('i' - 'a', 9, ['n' - 'a', 'i' - 'a', 'n' - 'a', 'e' - 'a'])];
        }

        private static List<(int, int, int[])> info;

        /// <summary>
        /// 遍历
        /// 按照这个顺序查找即可
        /// z -> zero, w -> two, u -> four, x -> six, g -> eight, o -> one, t -> three, s -> seven, f -> five, n -> nine
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string OriginalDigits(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s) freq[c - 'a']++;
            int key, val, _freq; int[] keys, cnts = new int[10];
            for (int i = 0; i < 10; i++)
            {
                (key, val, keys) = info[i];
                if (freq[key] > 0)
                {
                    _freq = freq[key];
                    cnts[val] = _freq;
                    foreach (int _key in keys) freq[_key] -= _freq;
                }
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 10; i++) for (int j = 0; j < cnts[i]; j++) result.Append(i);
            return result.ToString();
        }
    }
}
