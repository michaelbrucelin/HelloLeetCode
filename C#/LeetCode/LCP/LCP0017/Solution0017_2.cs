using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0017
{
    public class Solution0017_2 : Interface0017
    {
        /// <summary>
        /// 数学
        /// 纯粹没事增加点代码的乐趣，用矩阵来做一下
        /// A：2x+y | 2, 1 | x
        ///       y | 0 ,1 | y
        /// B：   x | 1, 0 | x
        ///    x+2y | 1 ,2 | y
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            int[,,] matrix = { { { 2, 1 }, { 0, 1 } }, { { 1, 0 }, { 1, 2 } } };
            int x = 1, y = 0;
            foreach (char c in s)
            {
                x = x * matrix[c - 'A', 0, 0] + y * matrix[c - 'A', 0, 1];
                y = x * matrix[c - 'A', 1, 0] + y * matrix[c - 'A', 1, 1];
            }

            return x + y;
        }
    }
}
