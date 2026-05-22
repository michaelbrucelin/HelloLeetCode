using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0033
{
    public class Solution0033_3 : Interface0033
    {
        /// <summary>
        /// 二分
        /// 1. 先二分找出数组最小值的位置
        /// 2. 然后二分查找目标
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;

            int minid = 0, low = 0, high = nums.Length - 1, mid;
            if (nums[0] > nums[^1])
            {
                while (low <= high)
                {
                    mid = low + ((high - low) >> 1);
                    if (nums[mid] >= nums[0]) low = mid + 1; else { minid = mid; high = mid - 1; }
                }
                if (target < nums[minid] || target > nums[minid - 1]) return -1;
                if (target >= nums[0]) { low = 0; high = minid - 1; } else { low = minid; high = nums.Length - 1; }
            }
            else
            {
                if (target > nums[^1] || target < nums[0]) return -1;
            }

            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                switch (nums[mid] - target)
                {
                    case > 0: high = mid - 1; break;
                    case < 0: low = mid + 1; break;
                    default: return mid;
                }
            }

            return -1;
        }
    }
}
