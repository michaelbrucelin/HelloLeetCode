using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1553
{
    public class Utils1553
    {
        public void Debug()
        {
            Interface1553 solution3 = new Solution1553_3();
            Interface1553 solution4 = new Solution1553_4();

            int n = 1, result3, result4;
            while (true)
            {
                result3 = solution3.MinDays(n);
                result4 = solution4.MinDays(n);
                if (result3 != result4)
                {
                    Console.WriteLine($"n = {n}, result3 = {result3}, result4 = {result4}");
                    break;
                }
                n++;
            }
        }
    }
}
