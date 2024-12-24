using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1486
{
    public class Solution1486 : Interface1486
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int XorOperation(int n, int start)
        {
            int result = 0;
            for (int i = 0; i < n; i++) result ^= start + (i << 1);

            return result;
        }
    }
}
