using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3201
{
    public class Solution3201 : Interface3201
    {
        /// <summary>
        /// 枚举
        /// 只有3种可能：
        ///     1 1 1 ... 1
        ///     0 0 0 ... 0
        ///     1 0 1 0 ... 或 0 1 0 1 ... 第一个值是0还是1，取决于数组的第一项
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumLength(int[] nums)
        {
            if (nums.Length == 2) return 2;

            int result, len = nums.Length, cnt = 0;
            for (int i = 0; i < len; i++) if ((nums[i] &= 1) == 0) cnt++;
            result = Math.Max(cnt, len - cnt);

            cnt = 1;
            for (int i = 1, j = 0; i < len; i++) if (nums[i] != nums[j])
                {
                    cnt++; j = i;
                }
            result = Math.Max(result, cnt);

            return result;
        }
    }
}
