using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1318
{
    public class Solution1318_2 : Interface1318
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int MinFlips(int a, int b, int c)
        {
            int result = 0, _a, _b, _c;
            for (int i = 0; i < 31; i++)
            {
                _a = a >> i & 1; _b = b >> i & 1; _c = c >> i & 1;
                result += (_c == 0 ? _a + _b : (_a + _b - 1) >>> 31);
            }

            return result;
        }
    }
}
