using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2552
{
    public class Solution2552 : Interface2552
    {
        /// <summary>
        /// 思路类似于Solution2552_err，只是预处理部分不同，思路与官解一致
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountQuadruplets(int[] nums)
        {
            long result = 0;
            int len = nums.Length;
            int[] lcnt = new int[len];
            for (int i = 1; i < len - 2; i++)
            {
                for (int j = nums[i - 1] + 1; j < len; j++) lcnt[j]++;
                for (int j = len - 2, rcnt = 0; j > i; j--)
                {
                    if (nums[j + 1] > nums[i]) rcnt++;
                    if (nums[j] < nums[i]) result += ((long)lcnt[nums[j]]) * rcnt;
                }
            }

            return result;
        }
    }
}
