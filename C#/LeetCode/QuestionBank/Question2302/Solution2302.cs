using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2302
{
    public class Solution2302 : Interface2302
    {
        /// <summary>
        /// 前缀和 + 二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, long k)
        {
            int len = nums.Length;
            long[] pres = new long[len + 1];
            for (int i = 0; i < len; i++) pres[i + 1] = pres[i] + nums[i];

            long result = 0;
            for (int i = 0; i < len; i++) if (nums[i] < k) result += binary_search(i) - i + 1;

            return result;

            int binary_search(int start)
            {
                int result = start;
                int l = start, r = len - 1, mid;
                while (l <= r)
                {
                    mid = l + ((r - l) >> 1);
                    if ((pres[mid + 1] - pres[start]) * (mid - start + 1) < k)
                    {
                        result = mid; l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return result;
            }
        }
    }
}
