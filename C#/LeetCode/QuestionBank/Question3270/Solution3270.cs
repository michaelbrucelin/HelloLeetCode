using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3270
{
    public class Solution3270 : Interface3270
    {
        public int GenerateKey(int num1, int num2, int num3)
        {
            int result = 0, pow = 1;
            for (int i = 0; i < 4; i++)
            {
                result += Math.Min(Math.Min(num1 % 10, num2 % 10), num3 % 10) * pow;
                num1 /= 10; num2 /= 10; num3 /= 10; pow *= 10;
            }

            return result;
        }
    }
}
