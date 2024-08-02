using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0189
{
    public class Solution0189_3 : Interface0189
    {
        /// <summary>
        /// 原地复制
        /// 示例1，k与len互质？
        /// [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] k = 3
        /// 从0开始，一点一点移动
        /// [?, 1, 2, 0, 4, 5, 6, 7, 8, 9]
        /// [?, 1, 2, 0, 4, 5, 3, 7, 8, 9]
        /// [?, 1, 2, 0, 4, 5, 3, 7, 8, 6]
        /// [?, 1, 9, 0, 4, 5, 3, 7, 8, 6]
        /// [?, 1, 9, 0, 4, 2, 3, 7, 8, 6]
        /// [?, 1, 9, 0, 4, 2, 3, 7, 5, 6]
        /// [?, 8, 9, 0, 4, 2, 3, 7, 5, 6]
        /// [?, 8, 9, 0, 1, 2, 3, 7, 5, 6]
        /// [?, 8, 9, 0, 1, 2, 3, 4, 5, 6]
        /// [7, 8, 9, 0, 1, 2, 3, 4, 5, 6]
        /// 示例2，回到0时，没有操作所有数据，那么从1开始继续
        /// [0, 1, 2, 3, 4, 5] k = 4
        /// [?, 1, 2, 3, 0, 5]
        /// [?, 1, 4, 3, 0, 5]
        /// [2, 1, 4, 3, 0, 5] 回到0，但是只操作了3个值，从1开始再来一轮
        /// [2, ?, 4, 3, 0, 1]
        /// [2, ?, 4, 5, 0, 1]
        /// [2, 3, 4, 5, 0, 1]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            k %= len;
            if (k == 0) return;

            int p, t1 = default, t2 = default, cnt = 0;
            for (int i = 0, j; cnt < len; i++)
            {
                j = i;
                t1 = nums[j]; p = (j + k) % len;
                while (p != j)
                {
                    t2 = nums[p]; nums[p] = t1; t1 = t2; cnt++;
                    p = (p + k) % len;
                }
                nums[p] = t2; cnt++;
            }
        }
    }
}
