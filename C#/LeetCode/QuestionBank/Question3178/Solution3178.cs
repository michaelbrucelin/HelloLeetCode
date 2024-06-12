using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3178
{
    public class Solution3178 : Interface3178
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfChild(int n, int k)
        {
            int ptr = 0, inc = 1;
            while (k-- > 0)
            {
                ptr += inc;
                if (ptr == 0) inc = 1; else if (ptr == n - 1) inc = -1;
            }

            return ptr;
        }
    }
}
