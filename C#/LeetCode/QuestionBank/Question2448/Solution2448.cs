using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2448
{
    public class Solution2448 : Interface2448
    {
        /// <summary>
        /// 中位数定理 + 二分
        /// 将nums排序，显然答案一定 min <= answer <= max，且 [min, answer] 单调不增，[answer, max] 单调不减
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public long MinCost(int[] nums, int[] cost)
        {
            throw new NotImplementedException();
        }
    }
}
