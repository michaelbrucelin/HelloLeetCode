using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0137
{
    public class Solution0137 : Interface0137
    {
        /// <summary>
        /// 每一个数字逐位累加，然后每一位对3取余，然后再转为十进制
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int[] buffer = new int[32];
            for (int i = 0; i < nums.Length; i++) for (int j = 0; j < 32; j++)
                    buffer[j] += (nums[i] >> j) & 1;

            for (int i = 0; i < buffer.Length; i++) buffer[i] %= 3;
            int result = 0;
            for (int i = 0; i < buffer.Length; i++) if (buffer[i] == 1) result |= (1 << i);

            return result;
        }
    }
}
