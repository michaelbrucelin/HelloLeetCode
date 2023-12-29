using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1837
{
    public class Utils1837
    {
        public void Dial()
        {
            int[,] dic = new int[9, 100];
            for (int i = 2; i <= 10; i++) for (int j = 1; j <= 100; j++)
                {
                    dic[i - 2, j - 1] = SumBase(j, i);
                }
            Utils.Dump(dic);
        }

        private int SumBase(int n, int k)
        {
            int result = 0;
            (int Quotient, int Remainder) info;
            while (n > 0)
            {
                info = Math.DivRem(n, k);
                result += info.Remainder;
                n = info.Quotient;
            }

            return result;
        }
    }
}
