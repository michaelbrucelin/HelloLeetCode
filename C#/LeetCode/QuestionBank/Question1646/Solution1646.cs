using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1646
{
    public class Solution1646 : Interface1646
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetMaximumGenerated(int n)
        {
            if (n < 2) return n;

            int[] nums = new int[n + 1];
            nums[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                if ((i & 1) != 0)
                    nums[i] = nums[i >> 1] + nums[(i >> 1) + 1];
                else
                    nums[i] = nums[i >> 1];
            }

            // return Math.Max(nums[^1], nums[^2]);  // error
            int max = nums[1];
            for (int i = 3; i <= n; i += 2) max = Math.Max(max, nums[i]);
            return max;
        }

        /// <summary>
        /// 与GetMaximumGenerated()逻辑一样，去掉了if-else判断
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetMaximumGenerated2(int n)
        {
            if (n < 2) return n;

            int[] nums = new int[n + 1];
            nums[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                nums[i] = nums[i >> 1] + (i & 1) * nums[(i >> 1) + 1];
            }

            int max = nums[1];
            for (int i = 3; i <= n; i += 2) max = Math.Max(max, nums[i]);
            return max;
        }
    }
}
