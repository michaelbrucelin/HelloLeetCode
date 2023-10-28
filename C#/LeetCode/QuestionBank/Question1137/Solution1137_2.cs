using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1137
{
    public class Solution1137_2 : Interface1137
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            int[] buffer = new int[] { 0, 1, 1, 2 };
            if (n < 4) return buffer[n];

            n -= 3;
            for (int i = 0; i < n; i++)
            {
                buffer[0] = buffer[1]; buffer[1] = buffer[2]; buffer[2] = buffer[3];
                buffer[3] = buffer[0] + buffer[1] + buffer[2];
            }

            return buffer[3];
        }
    }
}
