using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2333
{
    public class Solution2333_tle : Interface2333
    {
        /// <summary>
        /// 贪心+ 大顶堆
        /// 1. (x+1)^2 - x^2 = 2x+1，所以每次都应该让最大的“差距”缩小1
        /// 2. 总共有 k1 + k2 次机会
        /// 
        /// 逻辑没有问题，在k1+k2不是很大的情况下，这种写法是简单的，但是这道题k1+k2很大，所以一定会TLE
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k1"></param>
        /// <param name="k2"></param>
        /// <returns></returns>
        public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0, diff, len = nums1.Length; i < len; i++)
            {
                diff = Math.Abs(nums1[i] - nums2[i]);
                maxpq.Enqueue(diff, -diff);
            }

            k1 += k2;
            while (k1-- > 0)
            {
                if ((k2 = maxpq.Dequeue()) == 0) break;
                k2--;
                maxpq.Enqueue(k2, -k2);
            }

            long result = 0;
            foreach (var x in maxpq.UnorderedItems) result += 1L * x.Element * x.Element;
            return result;
        }
    }
}
