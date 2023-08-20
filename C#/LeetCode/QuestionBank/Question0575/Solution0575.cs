using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0575
{
    public class Solution0575 : Interface0575
    {
        /// <summary>
        /// 分析
        /// 就是取“种类数”与 n/2 的较小值
        /// </summary>
        /// <param name="candyType"></param>
        /// <returns></returns>
        public int DistributeCandies(int[] candyType)
        {
            int len = candyType.Length;
            HashSet<int> set = new HashSet<int>(candyType);

            return Math.Min(set.Count, len >> 1);
        }
    }
}
