using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3132
{
    public class Solution3132 : Interface3132
    {
        /// <summary>
        /// 排序 + 3次遍历
        /// 如果nums1[0]保留，遍历，还有2次移除机会
        /// 如果nums1[1]保留，遍历，还有1次移除机会
        /// 如果nums1[2]保留，遍历，还有0次移除机会
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinimumAddedInteger(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            int result = int.MaxValue, icr, drop, p1, p2, len = nums2.Length;
            // nums1[0]保留
            icr = nums2[0] - nums1[0]; drop = 2;
            for (p1 = 1, p2 = 1; p2 < len; p1++)
            {
                if (nums2[p2] - nums1[p1] != icr)
                {
                    if (--drop < 0) break;
                }
                else
                {
                    p2++;
                }
            }
            if (p2 == len) result = Math.Min(result, icr);

            // nums1[1]保留
            icr = nums2[0] - nums1[1]; drop = 1;
            for (p1 = 2, p2 = 1; p2 < len; p1++)
            {
                if (nums2[p2] - nums1[p1] != icr)
                {
                    if (--drop < 0) break;
                }
                else
                {
                    p2++;
                }
            }
            if (p2 == len) result = Math.Min(result, icr);

            // nums1[2]保留
            icr = nums2[0] - nums1[2]; drop = 0;
            for (p1 = 3, p2 = 1; p2 < len; p1++)
            {
                if (nums2[p2] - nums1[p1] != icr)
                {
                    if (--drop < 0) break;
                }
                else
                {
                    p2++;
                }
            }
            if (p2 == len) result = Math.Min(result, icr);

            return result;
        }

        /// <summary>
        /// 与MinimumAddedInteger()一样，从代码角度精简代码
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinimumAddedInteger2(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            int result = int.MaxValue, icr, drop, p1, p2, len = nums2.Length;
            int[] p1s = [0, 1, 2];  // [nums1[0]保留, nums1[1]保留, nums1[2]保留]
            for (int i = 0; i < 3; i++)
            {
                icr = nums2[0] - nums1[p1s[i]]; drop = 2 - p1s[i];
                for (p1 = p1s[i] + 1, p2 = 1; p2 < len; p1++)
                {
                    if (nums2[p2] - nums1[p1] != icr)
                    {
                        if (--drop < 0) break;
                    }
                    else
                    {
                        p2++;
                    }
                }
                if (p2 == len) result = Math.Min(result, icr);
            }

            return result;
        }
    }
}
