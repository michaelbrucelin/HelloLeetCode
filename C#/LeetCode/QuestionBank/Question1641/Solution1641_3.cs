using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1641
{
    public class Solution1641_3 : Interface1641
    {
        public int CountVowelStrings(int n)
        {
            return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
        }

        /// <summary>
        /// 能除就先除，然后再乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelStrings2(int n)
        {
            return ((n + 1) * (n + 2) >> 1) * (n + 3) / 3 * (n + 4) >> 2;
        }
    }
}
