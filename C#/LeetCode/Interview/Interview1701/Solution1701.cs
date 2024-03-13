using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1701
{
    public class Solution1701 : Interface1701
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Add(int a, int b)
        {
            int result = 0, carry = 0, _a, _b;
            for (int i = 0; i < 32; i++)
            {
                _a = (a >> i) & 1; _b = (b >> i) & 1;
                switch ((_a, _b, carry))
                {
                    case (0, 0, 0): break;
                    case (1, 0, 0):
                    case (0, 1, 0):
                    case (0, 0, 1):
                        result |= 1 << i;
                        carry = 0;
                        break;
                    case (1, 1, 0):
                    case (1, 0, 1):
                    case (0, 1, 1):
                        carry = 1;
                        break;
                    case (1, 1, 1):
                        result |= 1 << i;
                        break;
                    default: break;
                }
            }

            return result;
        }
    }
}
