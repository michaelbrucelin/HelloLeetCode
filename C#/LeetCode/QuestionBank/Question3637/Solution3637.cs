using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3637
{
    public class Solution3637 : Interface3637
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsTrionic(int[] nums)
        {
            if (nums.Length < 4 || nums[1] <= nums[0]) return false;

            int target = 2, times = 0, len = nums.Length;
            bool flag = true;
            for (int i = 1; i < len && times <= target; i++) if (nums[i] == nums[i - 1]) return false;
                else
                {
                    if (nums[i] > nums[i - 1] != flag)
                    {
                        flag = !flag;
                        times++;
                    }
                }

            return times == target;
        }
    }
}
