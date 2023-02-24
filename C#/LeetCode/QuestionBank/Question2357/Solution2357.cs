using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2357
{
    public class Solution2357 : Interface2357
    {
        /// <summary>
        /// 直接操作数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            int result = 0, len = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 0) continue;
                for (int j = len - 1; j >= i; j--) nums[j] -= nums[i];
                result++;
            }

            return result;
        }

        /// <summary>
        /// 简单优化
        /// 去重复值，显然这里重复值是没有意义的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations2(int[] nums)
        {
            int result = 0;
            nums = nums.Distinct().Where(i => i > 0).OrderBy(i => i).ToArray();
            for (int i = 0, len = nums.Length; i < len; i++)
            {
                for (int j = len - 1; j >= i; j--) nums[j] -= nums[i];
                result++;
            }

            return result;
        }

        /// <summary>
        /// 数学解
        /// 从MinimumOperations2()中可以看出，去0去重复后，每次操作都只能把最小的非0元素置为0，所以元素的数量就是操作数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations3(int[] nums)
        {
            return nums.Distinct().Where(i => i > 0).Count();
        }
    }
}
