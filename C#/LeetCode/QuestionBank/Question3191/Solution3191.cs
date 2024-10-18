using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3191
{
    public class Solution3191 : Interface3191
    {
        /// <summary>
        /// 数学，贪心
        /// 1. 如果左侧全部为1，则左侧这一部分不能做任何操作
        ///     如果做了任意操作，如果再做一次相同的操作，徒增加两次无用的操作，如果不再做相同的操作，那个将第一次操作后的0恢复为1，就会引发更多1变成0
        /// 2. 有了第一条，那么数组的第1个0，只有一种操作方式，即这个0与紧随的2个位置进行一次操作
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            int cnt = 0, len = nums.Length, p = 0;
            while (p < len)
            {
                if (nums[p] == 1)
                {
                    p++;
                }
                else
                {
                    if (p + 2 >= len) return -1;
                    nums[p] = 1 - nums[p];
                    nums[p + 1] = 1 - nums[p + 1];
                    nums[p + 2] = 1 - nums[p + 2];
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
