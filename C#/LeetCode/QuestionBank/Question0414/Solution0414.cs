using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0414
{
    public class Solution0414 : Interface0414
    {
        public int ThirdMax(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] : nums[1];

            long first = long.MinValue, second = long.MinValue, third = long.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val > first)
                {
                    third = second; second = first; first = val;
                }
                else if (first > val && val > second)
                {
                    third = second; second = val;
                }
                else if (second > val && val > third)
                {
                    third = val;
                }
            }

            return (int)(third == long.MinValue ? first : third);
        }

        public int ThirdMax2(int[] nums)
        {
            int[] _nums = nums.Distinct().OrderByDescending(i => i).ToArray();

            return _nums.Length < 3 ? _nums[0] : _nums[2];
        }
    }
}
