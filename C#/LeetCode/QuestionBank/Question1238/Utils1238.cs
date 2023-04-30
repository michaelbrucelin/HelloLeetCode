using LeetCode.Utilses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1238
{
    public class Utils1238
    {
        public void Dial()
        {
            int[] seed = new int[] { 0 };
            for (int i = 1; i <= 16; i++)
            {
                int len = 1 << (i - 1);
                int[] buffer = new int[len << 1]; Array.Copy(seed, buffer, len);
                for (int j = 0; j < len; j++)
                {
                    buffer[len + j] = buffer[len - j - 1] | len;
                }

                Console.WriteLine(Utils.ArrayToString(buffer));
                seed = buffer;
            }
        }
    }
}
