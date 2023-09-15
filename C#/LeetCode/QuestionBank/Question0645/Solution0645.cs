using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0645
{
    public class Solution0645 : Interface0645
    {
        /// <summary>
        /// 坑，重复值放第一项，缺失值放第二项
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            int[] result = new int[2];
            HashSet<int> set = new HashSet<int>();
            int i = 0, sum = 0, len = nums.Length;
            for (; i < len; i++)
            {
                sum += nums[i];
                if (set.Contains(nums[i]))
                {
                    result[0] = nums[i]; break;
                }
                else
                {
                    set.Add(nums[i]);
                }
            }
            for (i++; i < len; i++) sum += nums[i];
            result[1] = (((len + 1) * len) >> 1) - sum + result[0];

            return result;
        }
    }
}
