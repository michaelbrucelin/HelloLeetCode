using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3432
{
    public class Solution3432 : Interface3432
    {
        /// <summary>
        /// 脑筋急转弯
        /// 统计奇数的个数即可，即两个子数组中奇数的奇偶性应该相同
        ///     如果奇数总数是奇数，无解
        ///     如果奇数总数是偶数，怎样分都是解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountPartitions(int[] nums)
        {
            int oddcnt = 0, len = nums.Length;
            for (int i = 0; i < len; i++) oddcnt += nums[i] & 1;

            return (oddcnt & 1) != 0 ? 0 : len - 1;
        }

        public int CountPartitions2(int[] nums)
        {
            int oddcnt = 0, len = nums.Length;
            for (int i = 0; i < len; i++) oddcnt += nums[i] & 1;

            return ((oddcnt & 1) ^ 1) * (len - 1);
        }
    }
}
