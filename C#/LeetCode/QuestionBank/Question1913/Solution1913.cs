using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1913
{
    public class Solution1913 : Interface1913
    {
        public int MaxProductDifference(int[] nums)
        {
            int max1, max2, min1, min2;
            max1 = max2 = 0; min1 = min2 = 10001;
            for (int i = 0, num; i < nums.Length; i++)
            {
                num = nums[i];
                if (num > max1) { max2 = max1; max1 = num; }
                else if (num > max2) max2 = num;
                if (num < min1) { min2 = min1; min1 = num; }
                else if (num < min2) min2 = num;
            }

            return max1 * max2 - min1 * min2;
        }
    }
}
