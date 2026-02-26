using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1404
{
    public class Solution1404 : Interface1404
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumSteps(string s)
        {
            int result = 0, carry = 0;
            for (int i = s.Length - 1, x; i > 0; i--)
            {
                x = s[i] & 1;
                switch ((carry, x))
                {
                    case (0, 0): result++; break;
                    case (1, 0): result += 2; break;
                    case (0, 1): result += 2; carry = 1; break;
                    case (1, 1): result++; break;
                    default: break;
                }
            }
            if (carry == 1 && s[0] == '1') result++;

            return result;
        }
    }
}
