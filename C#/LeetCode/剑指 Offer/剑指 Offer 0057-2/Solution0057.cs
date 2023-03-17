using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0057_2
{
    public class Solution0057 : Interface0057
    {
        /// <summary>
        /// 二分法
        /// 1. i, i+1, i+2, ... j-1, j 的和是(i+j)(j-i+1)/2
        /// 2. 遍历[1, target-1]，对于遍历的每个i，使用二分法在[i+1,target-1]之间找结果
        /// 3. 由于子数组长度至少为2，所以不需要遍历[1, target-1]，遍历[1, (target-1)/2]即可
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[][] FindContinuousSequence(int target)
        {
            List<int[]> result = new List<int[]>();
            int limit = (target - 1) >> 1;
            for (int i = 1, j; i <= limit; i++)
            {
                if ((j = BinarySearch(i, i + 1, target - 1, target)) != -1)
                {
                    // result.Add(Enumerable.Range(i, j - i + 1).ToArray());
                    int[] _result = new int[j - i + 1];
                    for (int k = 0; k < _result.Length; k++) _result[k] = i + k;
                    result.Add(_result);
                }
            }

            return result.ToArray();
        }

        private int BinarySearch(int start, long left, long right, int target)
        {
            long mid, sum; while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                sum = ((start + mid) * (mid - start + 1)) >> 1;
                if (sum == target) return (int)mid;
                else if (sum < target) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }
    }
}
