using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1523
{
    public class Solution1523 : Interface1523
    {
        /// <summary>
        /// 分析
        /// 将 [奇, 奇] [奇, 偶] [偶, 奇] [偶, 偶] 4种情况逐一分析一下即可
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountOdds(int low, int high)
        {
            int result = (high - low) >> 1;
            return ((low & 1) != 1 && (high & 1) != 1) ? result : result + 1;
        }

        public int CountOdds2(int low, int high)
        {
            return ((high - low) >> 1) + ((low | high) & 1);
        }
    }
}
