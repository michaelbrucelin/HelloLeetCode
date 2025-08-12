using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0326
{
    public class Solution0326_err : Interface0326
    {
        /// <summary>
        /// 理论上是正确的，但是精度不够，会导致错误，例如n = 243
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            double log = Math.Log(n, 3);
            return log - (int)log == 0;
        }
    }
}
