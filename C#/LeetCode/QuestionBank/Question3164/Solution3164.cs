using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3164
{
    public class Solution3164 : Interface3164
    {
        /// <summary>
        /// Hash表
        /// 1. nums1中只保留可以被k整除的数字，并记录每个数字的频次，以及最大的数字
        /// 2. nums2中每个数字，*1 *2 ... *n，直至超过步骤1中的最大值
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            long result = 0;
            Dictionary<int, int> freq1 = new Dictionary<int, int>();
            Dictionary<int, int> freq2 = new Dictionary<int, int>();
            int key, max = -1;
            foreach (int num in nums1) if (num % k == 0)
                {
                    key = num / k;
                    if (freq1.ContainsKey(key)) freq1[key]++; else freq1.Add(key, 1);
                    max = Math.Max(max, key);
                }
            foreach (int num in nums2)
            {
                if (freq2.ContainsKey(num)) freq2[num]++; else freq2.Add(num, 1);
            }

            foreach (int num in nums2)
            {
                key = num;
                for (int i = 1; (key = num * i) <= max; i++) if (freq1.ContainsKey(key))
                    {
                        result += 1L * freq1[key] * freq2[num];
                    }
            }

            return result;
        }
    }
}
