using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0071
{
    public class Solution0071
    {
    }

    /// <summary>
    /// 将权重数组映射为权重的前缀和，二分找概率对应的值
    /// </summary>
    public class Solution : Interface0071
    {
        public Solution(int[] w)
        {
            weights = w;
            for (int i = 1; i < weights.Length; i++) weights[i] += weights[i - 1];
            upper = weights[^1] + 1;
        }

        private int[] weights;
        private int upper;
        // private readonly Random random = new Random();

        public int PickIndex()
        {
            // int target = random.Next(1, upper);
            int target = Random.Shared.Next(1, upper);
            return BinarySearch(target);
        }

        private int BinarySearch(int target)
        {
            int result = 0, left = 0, right = weights.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (weights[mid] > target)
                {
                    result = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
