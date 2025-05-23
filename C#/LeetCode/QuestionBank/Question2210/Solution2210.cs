﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2210
{
    public class Solution2210 : Interface2210
    {
        /// <summary>
        /// 遍历，双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountHillValley(int[] nums)
        {
            int result = 0, left = 1, right, len = nums.Length;
            while (left < len)
            {
                right = left;
                while (right + 1 < len && nums[right + 1] == nums[left]) right++;
                if (right == len - 1) break;
                if ((nums[left] > nums[left - 1] && nums[right] > nums[right + 1]) ||
                    (nums[left] < nums[left - 1] && nums[right] < nums[right + 1]))
                {
                    result++;
                }
                left = right + 1;
            }

            return result;
        }

        public int CountHillValley2(int[] nums)
        {
            int result = 0, len = nums.Length;
            bool isPeak;
            int ptr = 1;
            while (ptr < len && nums[ptr] == nums[ptr - 1]) ptr++;
            if (ptr == len) return 0;

            isPeak = nums[ptr] > nums[ptr - 1];
            while (ptr < len)
            {
                if (ptr + 1 < len && nums[ptr] != nums[ptr + 1])
                {
                    if (isPeak && nums[ptr] > nums[ptr + 1]) result++;
                    else if (!isPeak && nums[ptr] < nums[ptr + 1]) result++;
                    isPeak = nums[ptr + 1] > nums[ptr];
                }
                ptr++;
            }

            return result;
        }
    }
}
