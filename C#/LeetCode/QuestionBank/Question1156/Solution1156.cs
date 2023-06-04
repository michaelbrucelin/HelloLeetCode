using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1156
{
    public class Solution1156 : Interface1156
    {
        /// <summary>
        /// 分析
        /// 具体分析见Solution1156.md
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int MaxRepOpt1(string text)
        {
            int[] freq = new int[26];
            List<(int l, int r)> dist = new List<(int l, int r)>();
            freq[text[0] - 'a'] = 1;
            int len = text.Length, left = 0, right = 0;
            for (int i = 1; i < len; i++)
            {
                freq[text[i] - 'a']++;
                if (text[i] != text[left])
                {
                    dist.Add((left, right));
                    left = i;
                }
                right = i;
            }
            dist.Add((left, right));

            int result = 1, _result;
            char c; (int l, int r) t1; int cnt1, cnt2;
            for (int i = 0; i < dist.Count; i++)
            {
                _result = 1;
                t1 = dist[i]; c = text[t1.l]; cnt1 = t1.r - t1.l + 1;
                if (cnt1 == freq[c - 'a']) { _result = cnt1; }
                else
                {
                    // 调整左侧
                    if (t1.l - 2 >= 0)
                    {
                        if (text[t1.l - 2] != c) { _result = cnt1 + 1; }
                        else
                        {
                            cnt2 = dist[i - 2].r - dist[i - 2].l + 1;
                            _result = cnt1 + cnt2 != freq[c - 'a'] ? cnt1 + cnt2 + 1 : cnt1 + cnt2;
                        }
                    }
                    else if (t1.l - 1 >= 0) { _result = cnt1 + 1; }

                    // 调整右侧
                    if (t1.r + 2 < len)
                    {
                        if (text[t1.r + 2] != c) { _result = cnt1 + 1; }
                        else
                        {
                            cnt2 = dist[i + 2].r - dist[i + 2].l + 1;
                            _result = cnt1 + cnt2 != freq[c - 'a'] ? cnt1 + cnt2 + 1 : cnt1 + cnt2;
                        }
                    }
                    else if (t1.r + 1 >= 0) { _result = cnt1 + 1; }
                }

                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
