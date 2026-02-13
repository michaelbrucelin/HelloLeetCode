using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3714
{
    public class Solution3714_off : Interface3714
    {
        public int LongestBalanced(string s)
        {
            int result = Math.Min(s.Length, 2), _result, len = s.Length;

            // 1种字符
            _result = 1;
            for (int i = 1; i < len; i++)
            {
                if (s[i] == s[i - 1])
                {
                    _result++;
                }
                else
                {
                    result = Math.Max(result, _result); _result = 1;
                }
            }
            result = Math.Max(result, _result);

            // 2种字符
            int[,] cnts = new int[3, len + 1];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 3; j++) cnts[j, i + 1] = cnts[j, i];
                cnts[s[i] - 'a', i + 1]++;
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            result = Math.Max(result, TwoChars('a', 'b'));
            result = Math.Max(result, TwoChars('a', 'c'));
            result = Math.Max(result, TwoChars('b', 'c'));

            // 3种字符
            Dictionary<(int, int), int> map2 = new Dictionary<(int, int), int>();
            map2.Add((0, 0), -1);
            for (int i = 0, k1, k2; i < len; i++)
            {
                k1 = cnts[1, i + 1] - cnts[0, i + 1]; k2 = cnts[2, i + 1] - cnts[1, i + 1];
                if (map2.TryGetValue((k1, k2), out int last)) result = Math.Max(result, i - last); else map2.Add((k1, k2), i);
            }

            return result;

            int TwoChars(char x, char y)
            {
                int result = 0, idx = x - 'a', idy = y - 'a', len = s.Length;
                map.Clear(); map.Add(0, -1);
                for (int i = 0, j = 0, key; i < len; i++)
                {
                    if (s[i] != x && s[i] != y)
                    {
                        map.Clear(); map.Add(0, i); j = i + 1;
                    }
                    else
                    {
                        key = (cnts[idx, i + 1] - cnts[idx, j]) - (cnts[idy, i + 1] - cnts[idy, j]);
                        if (map.TryGetValue(key, out int last)) result = Math.Max(result, i - last); else map.Add(key, i);
                    }
                }

                return result;
            }
        }
    }
}
