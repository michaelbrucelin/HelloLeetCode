using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3870
{
    public class Solution3870 : Interface3870
    {
        /// <summary>
        /// 分段函数
        /// 简单题简单做
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountCommas(int n)
        {
            return n < 1000 ? 0 : n - 999;  // 题目限定 n <= 100,000
        }
    }
}
