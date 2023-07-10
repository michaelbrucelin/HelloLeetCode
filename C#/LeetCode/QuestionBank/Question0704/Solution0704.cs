using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0704
{
    public class Solution0704 : Interface0704
    {
        public int Search(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] < target) low = mid + 1;
                else if (nums[mid] > target) high = mid - 1;
                else return mid;
            }

            return -1;
        }
    }
}
