using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2333
{
    public class Solution2333 : Interface2333
    {
        /// <summary>
        /// 贪心 + 大顶堆
        /// 核心思路与Soluition2333_tle完全一致，做了优化，但是代码也难看了，显得不是那么优雅
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k1"></param>
        /// <param name="k2"></param>
        /// <returns></returns>
        public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
        {
            if (nums1.Length == 1)
            {
                int diff = Math.Abs(nums1[0] - nums2[0]);
                return k1 + k2 < diff ? 1L * (diff - k1 - k2) * (diff - k1 - k2) : 0;
            }

            long result = 0; int len = nums1.Length;
            if (k1 + k2 == 0)
            {
                for (int i = 0, diff; i < len; i++) result += 1L * (diff = Math.Abs(nums1[i] - nums2[i])) * diff;
                return result;
            }

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, diff; i < len; i++)
                if (map.TryGetValue(diff = Math.Abs(nums1[i] - nums2[i]), out int cnt)) map[diff] = ++cnt; else map.Add(diff, 1);
            PriorityQueue<(int, int), int> maxpq = new PriorityQueue<(int, int), int>();
            foreach (int key in map.Keys) maxpq.Enqueue((key, map[key]), -key);

            int k = k1 + k2, num1, cnt1, num2, cnt2, Q, R;
            while (k > 0)
            {
                (num1, cnt1) = maxpq.Dequeue();
                if (num1 == 0) break;

                if (maxpq.Count == 0)
                {
                    if (k >= 1L * num1 * cnt1) return 0;
                    (Q, R) = Math.DivRem(k, cnt1);
                    return 1L * (num1 - Q - 1) * (num1 - Q - 1) * R + 1L * (num1 - Q) * (num1 - Q) * (cnt1 - R);
                }
                else
                {
                    (num2, cnt2) = maxpq.Dequeue();
                    if (k >= 1L * (num1 - num2) * cnt1)
                    {
                        maxpq.Enqueue((num2, cnt1 + cnt2), -num2);
                        k -= (num1 - num2) * cnt1;
                    }
                    else
                    {
                        (Q, R) = Math.DivRem(k, cnt1);
                        k = 0;
                        if ((num1 - Q - 1) == num2)
                        {
                            maxpq.Enqueue((num2, cnt2 + R), -num2);
                        }
                        else
                        {
                            maxpq.Enqueue((num1 - Q - 1, R), -(num1 - Q - 1));
                            maxpq.Enqueue((num2, cnt2), -num2);
                        }
                        maxpq.Enqueue((num1 - Q, cnt1 - R), -(num1 - Q));
                    }
                }
            }

            foreach (var x in maxpq.UnorderedItems) result += 1L * x.Element.Item1 * x.Element.Item1 * x.Element.Item2;
            return result;
        }
    }
}
