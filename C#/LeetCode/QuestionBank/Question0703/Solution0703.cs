using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0703
{
    public class Solution0703
    {
    }

    public class KthLargest : Interface0703
    {
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="k"></param>
        /// <param name="nums"></param>
        public KthLargest(int k, int[] nums)
        {
            Array.Sort(nums);
            this.nums = new int[k];
            if (nums.Length >= k)
            {
                Array.Copy(nums, nums.Length - k, this.nums, 0, k);
            }
            else  // 由题目知，nums.Length == k - 1
            {
                Array.Copy(nums, 0, this.nums, 1, k - 1);
                this.nums[0] = int.MinValue;  // 哨兵
            }
        }

        private int[] nums;

        public int Add(int val)
        {
            int id = -1, left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] < val)
                {
                    id = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (id > -1)
            {
                for (int i = 0; i < id; i++) nums[i] = nums[i + 1];
                nums[id] = val;
            }

            return nums[0];
        }
    }
}
