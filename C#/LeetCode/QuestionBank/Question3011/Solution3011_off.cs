using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3011
{
    public class Solution3011_off : Interface3011
    {
        public bool CanSortArray(int[] nums)
        {
            int max = -1, _max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                if (BitCount(nums[i]) != BitCount(nums[i - 1]))
                {
                    max = _max; _max = nums[i];
                }
                if (nums[i] < max) return false;
                _max = Math.Max(_max, nums[i]);
            }

            return true;

            int BitCount(int num)
            {
                int count = 0;
                while (num > 0) { count++; num &= num - 1; }
                return count;
            }
        }
    }
}
