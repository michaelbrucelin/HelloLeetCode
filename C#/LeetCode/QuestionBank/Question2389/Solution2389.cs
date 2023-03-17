using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2389
{
    public class Solution2389 : Interface2389
    {
        /// <summary>
        /// 贪心
        /// 排序 --> 前缀和 --> 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            int[] sum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++) sum[i + 1] = sum[i] + nums[i];

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++) result[i] = BinarySearch(sum, queries[i]);

            return result;
        }

        private int BinarySearch(int[] nums, int target)
        {
            int result = 0, left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] <= target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
