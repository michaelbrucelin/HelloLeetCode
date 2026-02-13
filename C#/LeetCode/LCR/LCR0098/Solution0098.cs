using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0098
{
    public class Solution0098 : Interface0098
    {
        /// <summary>
        /// 排列组合
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            (m, n) = (m + n - 2, Math.Min(m, n) - 1);
            long result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= m - i; result /= i + 1;     // 这个顺序计算可以保证每一步都除尽，但是不保证中间过程不溢出
            }

            return (int)result;
        }
    }
}
