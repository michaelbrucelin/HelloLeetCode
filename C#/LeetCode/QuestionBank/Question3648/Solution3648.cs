using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3648
{
    public class Solution3648 : Interface3648
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinSensors(int n, int m, int k)
        {
            k <<= 1;
            return ((m + k) / (k + 1)) * ((n + k) / (k + 1));
        }
    }
}
