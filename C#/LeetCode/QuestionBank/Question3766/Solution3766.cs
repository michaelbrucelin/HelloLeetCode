using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3766
{
    public class Solution3766 : Interface3766
    {
        /// <summary>
        /// 暴力
        /// 预处理出数据范围内的全部的二进制回文数，然后暴力查找
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinOperations(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            List<bool> memory = [true, true];
            for (int i = 0, num, offset; i < len; i++)
            {
                num = nums[i]; offset = 0;
                if (num >= memory.Count)    // 懒预处理
                {
                    for (int x = memory.Count; x <= num; x++) memory.Add(check(x));
                    while (!memory[^1]) memory.Add(check(memory.Count));
                }
                while (!memory[num + offset] && !memory[num - offset]) offset++;
                result[i] = offset;
            }

            return result;

            static bool check(int x)
            {
                int _x = x, y = 0;
                while (_x > 0) { y <<= 1; y |= _x & 1; _x >>= 1; }
                return y == x;
            }
        }
    }
}
