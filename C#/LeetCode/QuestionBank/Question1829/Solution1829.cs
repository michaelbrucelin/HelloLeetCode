using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1829
{
    public class Solution1829 : Interface1829
    {
        /// <summary>
        /// 遍历
        /// 每次异或的结果一定是 mask = (1<<maximumBit)-1
        /// 令 xor = num1 ^ num2 ... ^numn
        ///     xor ^ k = mask --> xor ^ xor ^ k = xor^mask --> k = xor^mask
        ///     num1 ^ num2 ... ^num_{n-1} = xor ^ numn
        /// 
        /// 题目限定的数组有序有什么意义呢？迷惑人用的？
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="maximumBit"></param>
        /// <returns></returns>
        public int[] GetMaximumXor(int[] nums, int maximumBit)
        {
            int xor = 0, mask = (1 << maximumBit) - 1, len = nums.Length;
            for (int i = 0; i < len; i++) xor ^= nums[i];
            int[] result = new int[len];
            result[0] = xor ^ mask;
            for (int i = 1, j = len - 1; i < len; i++, j--)
            {
                xor ^= nums[j];
                result[i] = xor ^ mask;
            }

            return result;
        }
    }
}
