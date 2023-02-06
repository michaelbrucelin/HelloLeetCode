using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0350
{
    public class Solution0350 : Interface0350
    {
        /// <summary>
        /// hash表
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> freq1 = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++) if (freq1.ContainsKey(nums1[i])) freq1[nums1[i]]++; else freq1.Add(nums1[i], 1);
            Dictionary<int, int> freq2 = new Dictionary<int, int>();
            for (int i = 0; i < nums2.Length; i++) if (freq2.ContainsKey(nums2[i])) freq2[nums2[i]]++; else freq2.Add(nums2[i], 1);

            if (freq1.Count > freq2.Count) { var t = freq1; freq1 = freq2; freq2 = t; }  // 小表驱动大表

            List<int> result = new List<int>();
            foreach (var kv in freq1)
            {
                if (freq2.ContainsKey(kv.Key))
                {
                    int cnt = Math.Min(kv.Value, freq2[kv.Key]);
                    for (int i = 0; i < cnt; i++) result.Add(kv.Key);
                }
            }

            return result.ToArray();
        }
    }
}
