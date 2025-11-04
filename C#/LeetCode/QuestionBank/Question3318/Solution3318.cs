using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3318
{
    public class Solution3318 : Interface3318
    {
        /// <summary>
        /// 暴力查找
        /// 简单题，暴力解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int[] FindXSum(int[] nums, int k, int x)
        {
            int len = nums.Length;
            int[] result = new int[len - k + 1];

            if (x == k)
            {
                for (int i = k - 1; i >= 0; i--) result[0] += nums[i];
                for (int i = k; i < len; i++) result[i - k + 1] = result[i - k] - nums[i - k] + nums[i];
            }
            else
            {
                for (int i = 0; i <= len - k; i++)
                {
                    result[i] = nums.Skip(i).Take(k).GroupBy(y => y).OrderByDescending(y => y.Count()).ThenByDescending(y => y.Key).Take(x).Sum(y => y.Sum());
                }
            }

            return result;
        }

        public int[] FindXSum2(int[] nums, int k, int x)
        {
            int len = nums.Length;
            int[] result = new int[len - k + 1];

            if (x == k)
            {
                for (int i = k - 1; i >= 0; i--) result[0] += nums[i];
                for (int i = k; i < len; i++) result[i - k + 1] = result[i - k] - nums[i - k] + nums[i];
            }
            else
            {
                Parallel.For(0, len - k + 1, i => result[i] = nums.Skip(i).Take(k).GroupBy(y => y).OrderByDescending(y => y.Count()).ThenByDescending(y => y.Key).Take(x).Sum(y => y.Sum()));
            }

            return result;
        }
    }
}
