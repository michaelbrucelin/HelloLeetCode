using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1483.TestCases
{
    public class Solution1483_3 : Interface1483
    {
        /// <summary>
        /// 倍增，二进制预处理
        /// Solution1483是没有预处理，TLE，Solution1483_2相当于（惰性）预处理的所有的可能，OLE
        /// 所以这里采用倍增的方式预处理，即预处理出 y = 1, 2, 4, 8, 16 ... 2^x 的值
        ///     当计算 k 的结果时，一定可以通过预处理出来的结果计算出来（二进制）
        /// </summary>
        /// <param name="node"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthAncestor(int node, int k)
        {
            throw new NotImplementedException();
        }
    }
}
