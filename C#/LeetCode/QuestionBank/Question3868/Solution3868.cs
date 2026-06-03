using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3868
{
    public class Solution3868 : Interface3868
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinCost(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, len = nums1.Length; i < len; i++) { map.TryAdd(nums1[i], 0); map[nums1[i]]++; }
            for (int i = 0, len = nums2.Length; i < len; i++) { map.TryAdd(nums2[i], 0); map[nums2[i]]--; }

            int cnt1 = 0, cnt2 = 0;
            foreach (int cnt in map.Values)
            {
                if ((cnt & 1) != 0) return -1;
                if (cnt >= 0) cnt1 += cnt; else cnt2 -= cnt;
            }

            return cnt1 == cnt2 ? cnt1 >> 1 : -1;
        }
    }
}
