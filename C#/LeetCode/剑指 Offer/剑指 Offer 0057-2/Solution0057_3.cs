using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0057_2
{
    public class Solution0057_3 : Interface0057
    {
        /// <summary>
        /// 双指针
        /// 1. 使用两个指针，left->1，right->2
        /// 2. 固定left，right向右移，同时用变量sum记录[left, right]之间的和
        ///     如果sum < target，right继续向右移
        ///     如果sum = target，一个解，left向右移
        ///     如果sum > target，left向右移
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[][] FindContinuousSequence(int target)
        {
            List<int[]> result = new List<int[]>();
            int left = 1, right = 2; long sum = 3;
            while (left < right)
            {
                if (sum < target)
                {
                    sum += ++right;
                }
                else if (sum > target)
                {
                    sum -= left++;
                }
                else  // if (sum == target)
                {
                    result.Add(Enumerable.Range(left, right - left + 1).ToArray());
                    sum -= left++;
                }
            }

            return result.ToArray();
        }
    }
}
