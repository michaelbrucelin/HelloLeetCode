using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1863
{
    public class Solution1863 : Interface1863
    {
        /// <summary>
        /// 二进制枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SubsetXORSum(int[] nums)
        {
            int result = 0, _result, len = nums.Length;
            int cnt = 1 << len;
            for (int i = 1; i < cnt; i++)
            {
                _result = 0;
                for (int j = 0; j < len; j++) if ((i & (1 << j)) > 0) _result ^= nums[j];
                result += _result;
            }

            return result;
        }
    }
}
