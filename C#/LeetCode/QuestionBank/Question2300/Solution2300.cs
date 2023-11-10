using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2300
{
    public class Solution2300 : Interface2300
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="spells"></param>
        /// <param name="potions"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            int len = spells.Length, right = potions.Length;
            Array.Sort(potions);
            int[] result = new int[len];
            (long Quotient, long Remainder) info; int id;
            for (int i = 0; i < len; i++)
            {
                info = Math.DivRem(success, spells[i]);
                id = BinarySearch(potions, info.Quotient + (info.Remainder != 0 ? 1 : 0));
                result[i] = id == -1 ? 0 : right - id;
            }

            return result;
        }

        private int BinarySearch(int[] nums, long target)
        {
            int result = -1, left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] >= target)
                {
                    result = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
