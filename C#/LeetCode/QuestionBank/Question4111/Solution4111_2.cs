using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4111
{
    public class Solution4111_2 : Interface4111
    {
        /// <summary>
        /// 贡献法
        /// 枚举 nums[i] 为子数组的最小值同时又是子数组的与结果的数量
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountConsistent(int[] nums)
        {
            int result = 0, lcnt, rcnt, len = nums.Length;
            for (int i = 0, j; i < len; i++)
            {
                lcnt = 1; j = i; while (--j >= 0 && nums[j] >= nums[i] && (nums[j] & nums[i]) == nums[i]) lcnt++;
                rcnt = 1; j = i; while (++j < len && nums[j] > nums[i] && (nums[j] & nums[i]) == nums[i]) rcnt++;
                result += lcnt * rcnt;
            }

            return result;
        }
    }
}
