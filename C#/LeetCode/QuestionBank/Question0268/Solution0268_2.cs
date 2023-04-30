using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0268
{
    public class Solution0268_2 : Interface0268
    {
        /// <summary>
        /// 原地hash
        /// 没有什么优越性，只是练习一下
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i && nums[i] < n) swap(nums, nums[i], i--);
            }

            for (int i = 0; i < n; i++) if (nums[i] != i) return i;
            return n;
        }

        private void swap(int[] nums, int i, int j)
        {
            int t = nums[i]; nums[i] = nums[j]; nums[j] = t;
        }
    }
}
