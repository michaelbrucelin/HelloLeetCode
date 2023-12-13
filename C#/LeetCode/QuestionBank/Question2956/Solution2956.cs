using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2956
{
    public class Solution2956 : Interface2956
    {
        /// <summary>
        /// 字典
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] FindIntersectionValues(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dic1 = new Dictionary<int, int>();
            foreach (int num in nums1) { dic1.TryAdd(num, 0); dic1[num]++; }
            Dictionary<int, int> dic2 = new Dictionary<int, int>();
            foreach (int num in nums2) { dic2.TryAdd(num, 0); dic2[num]++; }

            int[] result = new int[2];
            foreach (var kv in dic1) if (dic2.ContainsKey(kv.Key)) result[0] += kv.Value;
            foreach (var kv in dic2) if (dic1.ContainsKey(kv.Key)) result[1] += kv.Value;

            return result;
        }
    }
}
