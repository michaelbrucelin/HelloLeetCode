using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2962
{
    public class Solution2962 : Interface2962
    {
        /// <summary>
        /// 滑动窗口，双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, int k)
        {
            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);

            long result = 0;
            int pl = 0, pr = 0, cnt = 0;
            while (pl < len)
            {
                while (cnt < k && pr < len) if (nums[pr++] == max) cnt++;
                if (cnt < k) break;
                result += len - pr + 1;
                if (nums[pl++] == max) cnt--;
            }

            return result;
        }
    }
}
