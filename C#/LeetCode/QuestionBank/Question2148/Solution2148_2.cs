using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2148
{
    public class Solution2148_2 : Interface2148
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountElements(int[] nums)
        {
            Array.Sort(nums);
            int result = 0;
            for (int i = 0; i < nums.Length; i++) if (BinaryJudge(nums, i)) result++;

            return result;
        }

        private bool BinaryJudge(int[] nums, int id)
        {
            bool flag1 = false;
            int target = nums[id], low = 0, high = id - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] < target) { flag1 = true; break; } else high = mid - 1;
            }
            if (!flag1) return false;

            bool flag2 = false;
            low = id + 1; high = nums.Length - 1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] > target) { flag2 = true; break; } else low = mid + 1;
            }

            return flag2;
        }
    }
}
