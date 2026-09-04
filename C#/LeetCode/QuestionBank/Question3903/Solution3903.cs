using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3903
{
    public class Solution3903 : Interface3903
    {
        /// <summary>
        /// 暴力查找
        /// 可以单调栈优化，既然简单题且数据量小，先暴力试一下
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FirstStableIndex(int[] nums, int k)
        {
            int max = nums[0], min, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, nums[i]);
                min = nums[i];
                for (int j = i + 1; j < len; j++) min = Math.Min(min, nums[j]);
                if (max - min <= k) return i;
            }

            return -1;
        }

        /// <summary>
        /// 逻辑同FirstStableIndex()，添加剪枝
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FirstStableIndex2(int[] nums, int k)
        {
            int max = nums[0], min, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, nums[i]);
                min = nums[i];
                for (int j = i; j < len; j++)
                {
                    if (max - (min = Math.Min(min, nums[j])) > k) goto CONTINUE;
                }
                return i;
            CONTINUE:;
            }

            return -1;
        }
    }
}
