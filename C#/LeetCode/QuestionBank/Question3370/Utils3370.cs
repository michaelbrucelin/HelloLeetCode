using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3370
{
    public class Utils3370
    {
        public void Dial()
        {
            int[] dial = new int[1001];
            for (int i = 0; i <= 1000; i++) dial[i] = SmallestNumber(i);

            Utils.Dump(dial);

            int SmallestNumber(int n)
            {
                int border = 2;
                while (border <= n) border <<= 1;

                return border - 1;
            }
        }
    }
}
