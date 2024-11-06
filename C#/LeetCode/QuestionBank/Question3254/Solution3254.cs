using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3254
{
    public class Solution3254 : Interface3254
    {
        /// <summary>
        /// 双指针
        /// 双指针找出nums中全部的单调连续递增区间即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] ResultsArray(int[] nums, int k)
        {
            if (k == 1) return nums;

            int n = nums.Length, len = nums.Length - k + 1;
            int[] result = new int[len];

            if (k == 2)
            {
                for (int i = 0; i < len; i++) result[i] = nums[i + 1] == nums[i] + 1 ? nums[i + 1] : -1;
            }
            else
            {
                int pl = 0, pr = 1;
                while (pr < n)
                {
                    if (nums[pr] == nums[pr - 1] + 1)
                    {
                        pr++;
                    }
                    else
                    {
                        for (int i = pl; pr - i >= k; i++) result[i] = nums[i + k - 1];
                        for (int i = Math.Max(pr - k + 1, 0); i < Math.Min(pr, len); i++) result[i] = -1;
                        pl = pr; pr++;
                    }
                }
                for (int i = pl; i < len && pr - i >= k; i++) result[i] = nums[i + k - 1];
                for (int i = Math.Max(pr - k + 1, 0); i < len; i++) result[i] = -1;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同ResultsArray()，先赋初始值为-1，时间复杂度相当（稍慢），代码简单一点
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] ResultsArray2(int[] nums, int k)
        {
            if (k == 1) return nums;

            int n = nums.Length, len = nums.Length - k + 1;
            int[] result = new int[len];

            if (k == 2)
            {
                for (int i = 0; i < len; i++) result[i] = nums[i + 1] == nums[i] + 1 ? nums[i + 1] : -1;
            }
            else
            {
                Array.Fill(result, -1);
                int pl = 0, pr = 1;
                while (pr < n)
                {
                    if (nums[pr] == nums[pr - 1] + 1)
                    {
                        pr++;
                    }
                    else
                    {
                        for (int i = pl; pr - i >= k; i++) result[i] = nums[i + k - 1];
                        pl = pr; pr++;
                    }
                }
                for (int i = pl; i < len && pr - i >= k; i++) result[i] = nums[i + k - 1];
            }

            return result;
        }
    }
}
