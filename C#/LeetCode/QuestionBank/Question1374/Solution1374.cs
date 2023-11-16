using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1374
{
    public class Solution1374 : Interface1374
    {
        /// <summary>
        /// 数学
        /// 1. 偶数 = 1 + 奇数
        /// 2. 奇数 = 奇数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string GenerateTheString(int n)
        {
            return (n & 1) != 0 ? $"{new string('a', n)}" : $"a{new string('b', n - 1)}";
        }
    }
}
