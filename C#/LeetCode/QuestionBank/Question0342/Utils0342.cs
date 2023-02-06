using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0342
{
    public class Utils0342
    {
        /// <summary>
        /// 1,4,16,64,256,1024,4096,16384,65536,262144,1048576,4194304,16777216,67108864,268435456,1073741824
        /// </summary>
        public void Print4Power()
        {
            int value = 1;
            Console.Write($"{value},");
            try
            {
                for (int i = 0; i < 32; i++) Console.Write($"{value << 2},");
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("done");
            }
        }
    }
}
