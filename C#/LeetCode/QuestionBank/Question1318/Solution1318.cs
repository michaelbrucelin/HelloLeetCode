using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1318
{
    public class Solution1318 : Interface1318
    {
        /// <summary>
        /// 状态机
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int MinFlips(int a, int b, int c)
        {
            int result = 0;
            for (int i = 0; i < 31; i++) switch (a >> i & 1, b >> i & 1, c >> i & 1)
                {
                    case (0, 0, 0): break;
                    case (0, 0, 1): result++; break;
                    case (0, 1, 0): result++; break;
                    case (0, 1, 1): break;
                    case (1, 0, 0): result++; break;
                    case (1, 0, 1): break;
                    case (1, 1, 0): result += 2; break;
                    case (1, 1, 1): break;
                    default: break;
                }

            return result;
        }
    }
}
