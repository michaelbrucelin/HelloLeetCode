using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3827
{
    public class Solution3827 : Interface3827
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountMonobit(int n)
        {
            int result = 1, _n = 1;
            while (_n <= n) { result++; _n = (_n << 1) + 1; }

            return result;
        }
    }
}
