using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3360
{
    public class Solution3360_2 : Interface3360
    {
        /// <summary>
        /// 数学
        /// x + (x+1) + (x+2) + ... + 10 = n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanAliceWin(int n)
        {
            int x = (int)Math.Ceiling(Math.Sqrt(110.25 - n - n) + 0.5);
            return (x & 1) != 1;
        }
    }
}
