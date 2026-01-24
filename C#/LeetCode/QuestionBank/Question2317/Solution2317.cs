using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2317
{
    public class Solution2317 : Interface2317
    {
        /// <summary>
        /// 逐位分析
        /// nums[i] AND (nums[i] XOR x)
        /// 1. nums[i] XOR x 可以是任意值，所以这一步运算没有实际意义，相当于nums[i] AND x
        /// 2. nums[i] AND x 可以把nums[i]为1的位置为0，无法将为0的为置为1
        /// 3. 所有元素异或，任意位，只要这一位至少有1个1，结果就为1（前面的操作可以将1置为0），如果这一位没有1，那么这一位就是0
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumXOR(int[] nums)
        {
            List<int> cnts = [];  // 记录每一位1的数量
            int len = nums.Length;
            for (int i = 0, j, num; i < len; i++)
            {
                j = 0; num = nums[i];
                while (num > 0)
                {
                    if (cnts.Count == j) cnts.Add(0);
                    cnts[j] += num & 1;
                    num >>= 1;
                    j++;
                }
            }

            int result = 0;
            for (int i = 0, b = 1; i < cnts.Count; i++, b <<= 1) if (cnts[i] > 0) result += b;
            return result;
        }
    }
}
