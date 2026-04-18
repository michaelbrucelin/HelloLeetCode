using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3694
{
    public class Solution3694 : Interface3694
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int DistinctPoints(string s, int k)
        {
            int x = 0, y = 0;
            foreach (char c in s) switch (c) { case 'U': y++; break; case 'D': y--; break; case 'L': x--; break; case 'R': x++; break; default: break; }

            HashSet<(int, int)> result = new HashSet<(int, int)>();
            int _x = 0, _y = 0, len = s.Length;
            for (int i = 0; i < k; i++) switch (s[i]) { case 'U': _y++; break; case 'D': _y--; break; case 'L': _x--; break; case 'R': _x++; break; default: break; }
            result.Add((x - _x, y - _y));
            for (int i = k; i < len; i++) if (s[i] != s[i - k])
                {
                    switch (s[i - 0]) { case 'U': _y++; break; case 'D': _y--; break; case 'L': _x--; break; case 'R': _x++; break; default: break; }
                    switch (s[i - k]) { case 'U': _y--; break; case 'D': _y++; break; case 'L': _x++; break; case 'R': _x--; break; default: break; }
                    result.Add((x - _x, y - _y));
                }

            return result.Count;
        }
    }
}
