using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3097
{
    public class Solution3097 : Interface3097
    {
        /// <summary>
        /// 滑动窗口
        /// 逻辑同Solution3095_3
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            if (k == 0) return 1;

            int result = int.MaxValue, pl = 0, pr = -1, len = nums.Length;
            int[] weight = new int[30];  // 题目限定num <= 1e9，30位够用
            while (++pr < len)
            {
                if (nums[pr] >= k) return 1;
                for (int i = 0; i < 30; i++) weight[i] += (nums[pr] >> i) & 1;
                while (GetOr() >= k)
                {
                    result = Math.Min(result, pr - pl + 1);
                    for (int i = 0; i < 30; i++) weight[i] -= (nums[pl] >> i) & 1;
                    pl++;
                }
            }

            return result != int.MaxValue ? result : -1;

            int GetOr()
            {
                int val = 0;
                for (int i = 0; i < 30; i++) val |= (weight[i] > 0 ? 1 : 0) << i;
                return val;
            }
        }
    }
}
