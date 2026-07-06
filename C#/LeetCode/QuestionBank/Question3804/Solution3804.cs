using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3804
{
    public class Solution3804 : Interface3804
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CenteredSubarrays(int[] nums)
        {
            int result = 0, len = nums.Length;
            HashSet<int> set = [];
            for (int i = 0, sum; i < len; i++)
            {
                set.Clear();
                sum = 0;
                for (int j = i; j < len; j++)
                {
                    set.Add(nums[j]);
                    if (set.Contains(sum += nums[j])) result++;
                }
            }

            return result;
        }
    }
}
