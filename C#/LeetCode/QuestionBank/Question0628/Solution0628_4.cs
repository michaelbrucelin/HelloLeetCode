using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0628
{
    public class Solution0628_4 : Interface0628
    {
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            int max1 = -1001, max2 = -1001, max3 = -1001, min1 = 1001, min2 = 1001;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (val > max3)
                {
                    max1 = max2; max2 = max3; max3 = val;
                }
                else if (val > max2)
                {
                    max1 = max2; max2 = val;
                }
                else if (val > max1)
                {
                    max1 = val;
                }

                if (val < min1)
                {
                    min2 = min1; min1 = val;
                }
                else if (val < min2)
                {
                    min2 = val;
                }
            }

            return Math.Max(max1 * max2 * max3, min1 * min2 * max3);
        }
    }
}
