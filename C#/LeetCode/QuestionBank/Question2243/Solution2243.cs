using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2243
{
    public class Solution2243 : Interface2243
    {
        public string DigitSum(string s, int k)
        {
            if (s.Length <= k) return s;

            StringBuilder buffer = new StringBuilder();
            int len; while ((len = s.Length) > k)
            {
                for (int i = 0, sum = 0; i < len; i += k, sum = 0)
                {
                    for (int j = 0; j < k; j++)
                        if (i + j < len) sum += s[i + j] & 15; else break;
                    buffer.Append($"{sum}");
                }
                s = buffer.ToString(); buffer.Clear();
            }

            return s;
        }

        public string DigitSum2(string s, int k)
        {
            if (s.Length <= k) return s;

            int len; while ((len = s.Length) > k)
            {
                s = string.Join("", Enumerable.Range(0, (len - 1) / k + 1)
                                              .Select(i => Enumerable.Range(i * k, Math.Min((i + 1) * k, len) - i * k)
                                                                     .Sum(j => s[j] & 15)
                                                                     .ToString()));
            }

            return s;
        }
    }
}
