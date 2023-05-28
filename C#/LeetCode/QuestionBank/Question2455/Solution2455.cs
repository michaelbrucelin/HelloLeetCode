using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2455
{
    public class Solution2455 : Interface2455
    {
        public int AverageValue(int[] nums)
        {
            int sum = 0, cnt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & 1) != 1 && nums[i] % 3 == 0)
                {
                    sum += nums[i]; cnt++;
                }
            }

            return cnt != 0 ? sum / cnt : 0;
        }
    }
}
