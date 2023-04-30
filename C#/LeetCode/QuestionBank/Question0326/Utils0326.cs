using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0326
{
    public class Utils0326
    {
        /// <summary>
        /// 1,3,9,27,81,243,729,2187,6561,19683,59049,177147,531441,1594323,4782969,14348907,43046721,129140163,387420489,1162261467
        /// </summary>
        public void Print3Power()
        {
            int value = 1;
            Console.Write($"{value},");
            try
            {
                for (int i = 0; i < 32; i++) Console.Write($"{value *= 3},");
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("done");
            }
        }
    }
}
