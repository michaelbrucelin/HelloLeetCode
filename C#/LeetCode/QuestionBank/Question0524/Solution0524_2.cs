using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0524
{
    public class Solution0524_2 : Interface0524
    {
        /// <summary>
        /// 贪心 + 二分
        /// 核心逻辑同Solution0524，将双指针暴力查找改为二分
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string FindLongestWord(string s, IList<string> dictionary)
        {
            int len = s.Length;
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = [];
            for (int i = 0; i < len; i++) dist[s[i] - 'a'].Add(i);

            string result = "";
            foreach (string word in dictionary) if (word.Length <= len && word.Length >= result.Length && check(word))
                {
                    // if (word.Length > result.Length || (word.Length == result.Length && string.CompareOrdinal(word, result) < 0)) result = word;
                    if (word.Length > result.Length || string.CompareOrdinal(word, result) < 0) result = word;
                }

            return result;

            bool check(string str)
            {
                int idx, left, right, mid, start = 0, _start;
                foreach (char c in str)
                {
                    if (dist[idx = c - 'a'].Count == 0 || dist[idx][^1] < start) return false;
                    left = 0; right = dist[idx].Count - 1; _start = -1;
                    while (left <= right)
                    {
                        mid = left + ((right - left) >> 1);
                        switch (dist[idx][mid] - start)
                        {
                            case > 0: _start = dist[idx][mid]; right = mid - 1; break;
                            case < 0: left = mid + 1; break;
                            default: _start = dist[idx][mid]; right = -1; break;
                        }
                    }
                    if (_start == -1) return false;
                    start = _start + 1;
                }
                return true;
            }
        }
    }
}
