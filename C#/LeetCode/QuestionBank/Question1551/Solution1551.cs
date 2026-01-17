using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1551
{
    public class Solution1551 : Interface1551
    {
        /// <summary>
        /// 数学
        /// n为偶数，结果是小于n的奇数的和，n为奇数，结果为小于n的偶数之和
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinOperations(int n)
        {
            return (n & 1) == 0 ? n * n >> 2 : (n + 1) * (n >> 1) >> 1;
        }

        public int MinOperations2(int n)
        {
            return (n + (n & 1)) * (n >> 1) >> 1;
        }

        public int MinOperations3(int n)
        {
            return n * n >> 2;
        }
    }
}
