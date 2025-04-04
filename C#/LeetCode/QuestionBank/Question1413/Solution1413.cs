﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1413
{
    public class Solution1413 : Interface1413
    {
        public int MinStartValue(int[] nums)
        {
            int min = nums[0];
            int sum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum < min) min = sum;
            }

            return min >= 0 ? 1 : 1 - min;
        }

        public int MinStartValue2(int[] nums)
        {
            int min = nums[0], sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                min = Math.Min(min, sum += nums[i]);
            }

            return min < 0 ? 1 - min : 1;
        }
    }
}
