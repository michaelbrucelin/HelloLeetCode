using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2602
{
    public class Solution2602 : Interface2602
    {
        /// <summary>
        /// 排序 + 前缀和 + 二分
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<long> MinOperations(int[] nums, int[] queries)
        {
            int len1 = nums.Length, len2 = queries.Length;
            long[] sums = new long[len1 + 1];
            Array.Sort(nums);
            for (int i = 0; i < len1; i++) sums[i + 1] = sums[i] + nums[i];

            long[] result = new long[len2];
            for (int i = 0, id, lo, hi, mid; i < len2; i++)
            {
                id = len1; lo = 0; hi = len1 - 1;
                while (lo <= hi)
                {
                    mid = lo + ((hi - lo) >> 1);
                    if (nums[mid] >= queries[i]) { id = mid; hi = mid - 1; } else lo = mid + 1;
                }
                result[i] = (1L * queries[i] * id - (sums[id] - sums[0])) + (sums[len1] - sums[id] - 1L * queries[i] * (len1 - id));
            }

            return result;
        }
    }
}
