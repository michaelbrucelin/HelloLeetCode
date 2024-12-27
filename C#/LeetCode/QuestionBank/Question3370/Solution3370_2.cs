using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3370
{
    public class Solution3370_2 : Interface3370
    {
        /// <summary>
        /// 逆二分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SmallestNumber(int n)
        {
            int border = 2;
            while (border <= n) border <<= 1;

            return border - 1;
        }
    }
}
