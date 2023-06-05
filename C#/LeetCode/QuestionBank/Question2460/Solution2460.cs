using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2460
{
    public class Solution2460 : Interface2460
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ApplyOperations(int[] nums)
        {
            int len = nums.Length;
            for (int i = 0; i < len - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] <<= 1; nums[i + 1] = 0; i++;
                }
            }

            int l = 0, r, t;
            while (true)
            {
                while (l < len && nums[l] != 0) l++;
                r = l + 1;
                while (r < len && nums[r] == 0) r++;
                if (r < len)
                {
                    t = nums[l]; nums[l] = nums[r]; nums[r] = t; l++;
                }
                else break;
            }

            return nums;
        }

        /// <summary>
        /// 模拟
        /// 稍加优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ApplyOperations2(int[] nums)
        {
            int len = nums.Length;
            for (int i = 0; i < len - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] <<= 1; nums[i + 1] = 0; i++;
                }
            }

            int l = 0, r, t;
            while (l < len && nums[l] != 0) l++; r = l + 1;
            while (true)
            {
                while (l < len && nums[l] != 0) l++;
                while (r < len && nums[r] == 0) r++;
                if (r < len)
                {
                    t = nums[l]; nums[l] = nums[r]; nums[r] = t; l++; r++;
                }
                else break;
            }

            return nums;
        }
    }
}
