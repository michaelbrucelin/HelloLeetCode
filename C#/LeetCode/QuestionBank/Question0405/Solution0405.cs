using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0405
{
    public class Solution0405 : Interface0405
    {
        private static readonly char[] map = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        /// <summary>
        /// 每4个二进制位换一次16进制即可
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ToHex(int num)
        {
            if (num == 0) return "0";

            char[] buffer = new char[8];
            for (int i = 0; i < 8; i++)
            {
                buffer[i] = map[(num >> ((7 - i) << 2)) & 15];
            }

            int id = 0; while (buffer[id] == '0') id++;
            return new string(buffer[id..]);
        }
    }
}
