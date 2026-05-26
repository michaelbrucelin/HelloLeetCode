using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3724
{
    public class Solution3724 : Interface3724
    {
        /// <summary>
        /// 分类讨论
        /// 需要讨论就是最后追加的那个元素
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public long MinOperations(int[] nums1, int[] nums2)
        {
            long result = 1; int last = int.MaxValue, len = nums1.Length;
            for (int i = 0; i < len; i++) result += Math.Abs(nums1[i] - nums2[i]);
            for (int i = 0; i < len; i++)
            {
                if (1L * (nums1[i] - nums2[^1]) * (nums2[i] - nums2[^1]) > 0)
                {
                    last = Math.Min(last, Math.Min(Math.Abs(nums1[i] - nums2[^1]), Math.Abs(nums2[i] - nums2[^1])));
                }
                else
                {
                    last = 0; break;
                }
            }

            return result + last;
        }
    }
}
