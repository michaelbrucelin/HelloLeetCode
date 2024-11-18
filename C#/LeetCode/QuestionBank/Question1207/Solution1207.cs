using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1207
{
    public class Solution1207 : Interface1207
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in arr) if (map.ContainsKey(num)) map[num]++; else map.Add(num, 0);

            HashSet<int> set = new HashSet<int>();
            foreach (int cnt in map.Values) if (set.Contains(cnt)) return false; else set.Add(cnt);

            return true;
        }

        public bool UniqueOccurrences2(int[] arr)
        {
            int[] freq = new int[2001];
            foreach (int num in arr) freq[num + 1000]++;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < 2001; i++) if (freq[i] > 0)
                {
                    if (set.Contains(freq[i])) return false; else set.Add(freq[i]);
                }

            return true;
        }
    }
}
