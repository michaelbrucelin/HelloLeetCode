using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3099
{
    public class Utils3099
    {
        public void Dial()
        {
            int[] result = new int[101];
            for (int i = 1; i <= 100; i++) result[i] = SumOfTheDigitsOfHarshadNumber(i);
            Utils.Dump(result);
        }

        private int SumOfTheDigitsOfHarshadNumber(int x)
        {
            int sum = 0, _x = x;
            while (_x > 0)
            {
                sum += _x % 10; _x /= 10;
            }

            return x % sum == 0 ? sum : -1;
        }
    }
}
