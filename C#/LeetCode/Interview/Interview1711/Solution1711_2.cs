using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1711
{
    public class Solution1711_2 : Interface1711
    {
        /// <summary>
        /// 预处理 + 双指针
        /// 应对题目中说的，如果会反复查询多次的场景
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int FindClosest(string[] words, string word1, string word2)
        {
            int len = words.Length;
            Dictionary<string, List<int>> pos = new Dictionary<string, List<int>>();
            for (int i = 0; i < len; i++) if (pos.TryGetValue(words[i], out var list)) list.Add(i); else pos.Add(words[i], [i]);
            if (!pos.ContainsKey(word1) || !pos.ContainsKey(word2)) return len;  // 验证过，如果wors1与word2不同时存在，结果是数组长度

            int result = words.Length;
            List<int> idx1 = pos[word1], idx2 = pos[word2];
            int p1 = 0, p2 = 0, cnt1 = idx1.Count, cnt2 = idx2.Count;
            while (p1 < cnt1 && p2 < cnt2)
            {
                if (idx1[p1] < idx2[p2])
                {
                    while (p1 + 1 < cnt1 && idx1[p1 + 1] < idx2[p2]) p1++;
                    result = Math.Min(result, idx2[p2] - idx1[p1]);
                    p1++;
                }
                else  // if (idx2[p2] < idx1[p1])
                {
                    while (p2 + 1 < cnt2 && idx2[p2 + 1] < idx1[p1]) p2++;
                    result = Math.Min(result, idx1[p1] - idx2[p2]);
                    p2++;
                }
            }

            return result;
        }
    }
}
