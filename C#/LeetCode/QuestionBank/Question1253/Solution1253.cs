using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1253
{
    public class Solution1253 : Interface1253
    {
        /// <summary>
        /// 分析构造
        /// 1. 下面两种情况无解
        ///     1. 如果upper+lower != colsum.Sum()，无解
        ///     2. 如果colsum中2的数量大于uppper或者lower，无解
        /// 2. 否则有解，按照下面的方式构造即可
        ///     1. colsum = 0的列，两行都置为0
        ///     2. colsum = 2的列，两行都置为1，假定有cnt2个列colsum = 2
        ///     3. 在第一行中随意找upper-cnt2个colsum = 1的列置为1
        ///     4. 在第二行中将余下的colsum = 1的列置为1
        /// </summary>
        /// <param name="upper"></param>
        /// <param name="lower"></param>
        /// <param name="colsum"></param>
        /// <returns></returns>
        public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {
            int sum = colsum.Sum(), cnt2 = colsum.Count(i => i == 2);
            if (upper + lower != sum || cnt2 > upper || cnt2 > lower) return new List<IList<int>>();

            int len = colsum.Length;
            int[][] result = new int[][] { new int[len], new int[len] };
            bool flag = upper - cnt2 != 0; int ucnt = upper - cnt2, _ucnt = 0, _sum = 0;
            for (int i = 0, bit; i < len; i++)
            {
                bit = colsum[i];
                switch (bit)
                {
                    case 2:
                        result[0][i] = result[1][i] = 1;
                        break;
                    case 1:
                        if (flag) { result[0][i] = 1; if (++_ucnt == ucnt) flag = false; }
                        else { result[1][i] = 1; }
                        break;
                    default:
                        break;
                }
                if ((_sum += bit) == sum) break;
            }

            return result;
        }
    }
}
