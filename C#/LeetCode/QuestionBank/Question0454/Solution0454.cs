using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0454
{
    public class Solution0454 : Interface0454
    {
        /// <summary>
        /// 预处理
        /// 预处理nums1与nums2中两两元素和到hash中
        /// 预处理nums3与nums4中两两元素和到hash中
        /// 枚举两个hash即可
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="nums3"></param>
        /// <param name="nums4"></param>
        /// <returns></returns>
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int n = nums1.Length;
            Dictionary<int, int> map1 = new Dictionary<int, int>(), map2 = new Dictionary<int, int>();
            int key;
            foreach (int v1 in nums1) foreach (int v2 in nums2)
                {
                    key = v1 + v2;
                    if (map1.TryGetValue(key, out int v)) map1[key] = ++v; else map1.Add(key, 1);
                }
            foreach (int v3 in nums3) foreach (int v4 in nums4)
                {
                    key = v3 + v4;
                    if (map2.TryGetValue(key, out int v)) map2[key] = ++v; else map2.Add(key, 1);
                }

            int result = 0;
            foreach (int k1 in map1.Keys) if (map2.TryGetValue(-k1, out int v2)) result += map1[k1] * v2;

            return result;
        }
    }
}
