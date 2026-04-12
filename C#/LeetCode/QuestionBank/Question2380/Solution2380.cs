using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2380
{
    public class Solution2380 : Interface2380
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int SecondsToRemoveOccurrences(string s)
        {
            int result = 0, len = s.Length;
            int[] chars = new int[len];
            for (int i = 0; i < len; i++) chars[i] = s[i] & 1;
            bool flag = true; int p, start = 0, end = len - 1, _end;
            while (flag)
            {
                flag = false; p = start + 1; _end = end;
                while (p <= end)
                {
                    if (chars[p - 1] == 0 && chars[p] == 1)
                    {
                        chars[p - 1] = 1; chars[p] = 0;
                        if (!flag) { flag = true; start = Math.Max(0, p - 2); }
                        _end = p - 1;
                        p += 2;
                    }
                    else
                    {
                        if (chars[p] == 1) _end = p; else if (chars[p - 1] == 1) _end = p - 1;
                        p++;
                    }
                }
                if (chars[end] != 1) end = _end;
                if (flag) result++; else break;
            }

            return result;
        }
    }
}
