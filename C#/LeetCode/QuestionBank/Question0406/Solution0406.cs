using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0406
{
    public class Solution0406 : Interface0406
    {
        /// <summary>
        /// 分析 item1 [h1, k1], item2 [h2, k2]
        /// h1 < h2 && k1 < k2 --> item1 < item2
        /// h1 < h2 && k1 = k2 --> item1 < item2
        /// h1 < h2 && k1 > k2 --> 没有顺序
        /// h1 = h2 && k1 < k2 --> item1 < item2
        /// h1 = h2 && k1 = k2 --> 不可能
        /// h1 = h2 && k1 > k2 --> item1 > item2
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public int[][] ReconstructQueue(int[][] people)
        {
            throw new NotImplementedException();
        }
    }
}
