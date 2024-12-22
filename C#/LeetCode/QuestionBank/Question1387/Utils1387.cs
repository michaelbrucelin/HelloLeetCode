using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1387
{
    public class Utils1387
    {
        public void Dial()
        {
            Console.Write("[-1");
            for (int i = 1; i <= 1000; i++)
            {
                // Console.WriteLine($"{i}\t{Convert.ToString(i, 2)}\t{GetWeight(i)}");
                Console.Write($",{GetWeight(i)}");
            }
            Console.WriteLine("]");

            int GetWeight(int x)
            {
                int step = 0;
                while (x != 1)
                {
                    x = (x & 1) == 0 ? x >> 1 : x * 3 + 1;
                    step++;
                }

                return step;
            }
        }
    }
}
