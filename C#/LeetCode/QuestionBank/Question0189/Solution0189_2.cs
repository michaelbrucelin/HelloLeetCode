using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0189
{
    public class Solution0189_2 : Interface0189
    {
        /// <summary>
        /// 原地复制
        /// 使用一个额外空间，k轮移动
        /// 
        /// 逻辑没问题，TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            k %= len;
            if (k == 0) return;

            if (k <= len / 2)
            {
                for (int i = 0, temp; i < k; i++)
                {
                    temp = nums[^1];
                    for (int j = len - 1; j > 0; j--) nums[j] = nums[j - 1];
                    nums[0] = temp;
                }
            }
            else
            {
                k = len - k;
                for (int i = 0, temp; i < k; i++)
                {
                    temp = nums[0];
                    for (int j = 0; j < len - 1; j++) nums[j] = nums[j + 1];
                    nums[^1] = temp;
                }
            }
        }
    }
}
