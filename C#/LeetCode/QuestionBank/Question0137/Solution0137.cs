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

        public int SingleNumber2(int[] nums)
        {
            sbyte[] bits = new sbyte[32];
            for (int i = 0, num; i < nums.Length; i++)
            {
                num = nums[i];
                for (int j = 0; j < 32; j++)
                {
                    bits[j] += (sbyte)((num >> j) & 1);
                    if (bits[j] == 3) bits[j] = 0;
                }
            }

            int result = 0;
            for (int i = 31; i >= 0; i--) result = (result << 1) + bits[i];
            return result;
        }

        /// <summary>
        /// 逻辑同SingleNumber()，但是设计更巧妙，本质上就是小学时学的手动算加法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber3(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                int bits = 0;
                for (int j = 0; j < nums.Length; j++) bits += (nums[j] >> i) & 1;
                if (bits % 3 != 0) result |= 1 << i;
            }

            return result;
        }
    }
}
