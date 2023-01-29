using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0231
{
    public class Utils0231
    {
        /// <summary>
        /// 1,2,4,8,16,32,64,128,256,512,1024,2048,4096,8192,16384,32768,65536,131072,262144,524288,1048576,2097152,4194304,8388608,16777216,33554432,67108864,134217728,268435456,536870912,1073741824
        /// </summary>
        public void Print2Power()
        {
            int value = 1;
            Console.Write($"{value},");
            for (int i = 0; i < 30; i++) Console.Write($"{value <<= 1},");
        }
    }
}
