using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0507
{
    public class Solution0507 : Interface0507
    {
        public bool CheckPerfectNumber(int num)
        {
            int result = 1, border = (int)Math.Sqrt(num);
            if (border * border == num) result += border--;
            for (int i = 2; i <= border; i++)
            {
                var info = Math.DivRem(num, i);
                if (info.Remainder == 0)
                {
                    result += i; result += info.Quotient;
                }
                if (result > num) return false;
            }

            return result == num;
        }

        public bool CheckPerfectNumber2(int num)
        {
            if (num == 1) return false;

            int sum = 1, boundary = (int)Math.Floor(Math.Sqrt(num));
            for (int i = 2; i <= boundary; i++)
            {
                if (num % i == 0)
                {
                    if ((sum += i + num / i) > num) return false;
                }
            }

            return sum == num;
        }
    }
}
