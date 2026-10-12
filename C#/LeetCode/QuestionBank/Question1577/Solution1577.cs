using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1577
{
    public class Solution1577 : Interface1577
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int NumTriplets(int[] nums1, int[] nums2)
        {
            int result = 0;
            result += _NumTriplets(nums1, nums2);
            result += _NumTriplets(nums2, nums1);

            return result;

            static int _NumTriplets(int[] nums1, int[] nums2)
            {
                Dictionary<long, int> map1 = new Dictionary<long, int>();
                long square;
                foreach (int x in nums1)
                {
                    square = 1L * x * x;
                    if (map1.TryGetValue(square, out int cnt)) map1[square] = ++cnt; else map1.Add(square, 1);
                }
                Dictionary<int, int> map2 = new Dictionary<int, int>();
                foreach (int x in nums2)
                {
                    if (map2.TryGetValue(x, out int cnt)) map2[x] = ++cnt; else map2.Add(x, 1);
                }

                int count = 0;
                foreach (int x in map2.Keys) foreach (int y in map2.Keys)
                    {
                        square = 1L * x * y;
                        if (map1.TryGetValue(square, out int cnt)) count += x != y ? map2[x] * map2[y] * cnt : map2[x] * (map2[x] - 1) * cnt;
                    }

                return count >> 1;
            }
        }
    }
}
