using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3397
{
    public class Solution3397 : Interface3397
    {
        /// <summary>
        /// 排序 + 贪心
        /// 每个值都转成可能的最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxDistinctElements(int[] nums, int k)
        {
            if (nums.Length == 1) return 1;
            if (k == 0) return nums.Distinct().Count();

            Array.Sort(nums);
            int result = 1, last = nums[0] - k, len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] - k > last)
                {
                    last = nums[i] - k; result++;
                }
                else if (nums[i] + k > last)
                {
                    last++; result++;
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑同MaxDistinctElements()，去掉linq试一下
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxDistinctElements2(int[] nums, int k)
        {
            if (nums.Length == 1) return 1;
            if (k == 0) return (new HashSet<int>(nums)).Count;

            Array.Sort(nums);
            int result = 1, last = nums[0] - k, len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] - k > last)
                {
                    last = nums[i] - k; result++;
                }
                else if (nums[i] + k > last)
                {
                    last++; result++;
                }
            }

            return result;
        }
    }
}
