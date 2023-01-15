using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2293
{
    public class Solution2293 : Interface2293
    {
        public int MinMaxGame(int[] nums)
        {
            int len = nums.Length;
            while (len > 1)
            {
                len >>= 1;
                bool ismin = true;
                for (int i = 0; i < len; i++)
                {
                    int id = i << 1;
                    if (ismin)
                    {
                        nums[i] = Math.Min(nums[id], nums[id + 1]);
                        ismin = false;
                    }
                    else
                    {
                        nums[i] = Math.Max(nums[id], nums[id + 1]);
                        ismin = true;
                    }
                }
            }

            return nums[0];
        }
    }
}
