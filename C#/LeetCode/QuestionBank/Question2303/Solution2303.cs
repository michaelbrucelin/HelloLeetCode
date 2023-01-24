using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2303
{
    public class Solution2303 : Interface2303
    {
        public double CalculateTax(int[][] brackets, int income)
        {
            double result = 0;
            int id = -1, last = 0, len = brackets.Length;
            while (++id < len)
            {
                int upper = brackets[id][0], percent = brackets[id][1];
                if (income >= upper)
                {
                    result += (double)(upper - last) * percent / 100;
                    last = upper;
                }
                else
                {
                    result += (double)(income - last) * percent / 100;
                    break;
                }
            }

            return result;
        }
    }
}
