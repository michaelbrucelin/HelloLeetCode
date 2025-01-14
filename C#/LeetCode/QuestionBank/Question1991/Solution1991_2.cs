using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1991
{
    public class Solution1991_2 : Interface1991
    {
        /// <summary>
        /// 前缀和 + 后缀和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMiddleIndex(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int prev = 0, tail = nums[1..].Sum();
            if (tail == 0) return 0;
            for (int i = 1; i < nums.Length; i++)
            {
                prev += nums[i - 1]; tail -= nums[i];
                if (prev == tail) return i;
            }

            return -1;
        }

        public int FindMiddleIndex2(int[] nums)
        {
            int lsum = 0, rsum = nums.Sum(), len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                rsum -= nums[i];
                if (lsum == rsum) return i;
                lsum += nums[i];
            }

            return -1;
        }
    }
}
