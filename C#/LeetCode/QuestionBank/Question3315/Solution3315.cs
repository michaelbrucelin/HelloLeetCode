using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3315
{
    public class Solution3315 : Interface3315
    {
        /// <summary>
        /// 位运算
        /// 逻辑同Solution3314_2
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinBitwiseArray(IList<int> nums)
        {
            int len = nums.Count;
            int[] result = new int[len];
            for (int i = 0, j = -1, num; i < len; i++, j = -1)
            {
                result[i] = -1; num = nums[i];
                if (num == 2) continue;              // 题目限定了质数，所以只有这一个偶数（特殊情况）
                while (((num >> (++j)) & 1) != 0) ;
                result[i] = num ^ (1 << (j - 1));
            }

            return result;
        }
    }
}
