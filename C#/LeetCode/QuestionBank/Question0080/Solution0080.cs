using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0080
{
    public class Solution0080 : Interface0080
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 3) return nums.Length;

            int p1 = 2, p2 = 2, len = nums.Length;
            while (p2 < len)
            {
                if (nums[p2] != nums[p1 - 2])
                {
                    nums[p1] = nums[p2]; p1++; p2++;
                }
                else
                {
                    p2++;
                }
            }

            return p1;
        }

        /// <summary>
        /// 逻辑同RemoveDuplicates()，做了些许优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length < 3) return nums.Length;

            int p1 = 2, p2 = 1, len = nums.Length;
            while (++p2 < len)
            {
                if (nums[p2] != nums[p1 - 2])
                {
                    nums[p1] = nums[p2]; p1++;
                }
            }

            return p1;
        } 
    }
}
