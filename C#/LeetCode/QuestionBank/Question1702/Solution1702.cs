using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1702
{
    public class Solution1702 : Interface1702
    {
        /// <summary>
        /// 构造
        /// 结论：假定字符串中共有x个0，最终的结果长度不变，且只有一个0，0的位置在第1个向右移动x-1位
        /// 论证：
        /// 假定有一个字串0111...10，两端是0，中间全部是1（x个），那么可以
        ///     1. 通过x次 10 -> 01，替换为 00111...1
        ///     2. 一次 00 -> 10，替换为 10111...1
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public string MaximumBinaryString(string binary)
        {
            if (binary.Length == 1) return binary;

            int cnt = 0, pos = binary.Length, len = binary.Length;
            for (int i = 0; i < len; i++) if (binary[i] == '0')
                {
                    cnt++; pos = Math.Min(pos, i);
                }
            if (cnt < 2) return binary;

            char[] result = new char[len];
            Array.Fill(result, '1'); result[pos + cnt - 1] = '0';

            return new string(result);
        }
    }
}
