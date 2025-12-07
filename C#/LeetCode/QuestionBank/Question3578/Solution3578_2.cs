using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3578
{
    public class Solution3578_2 : Interface3578
    {
        /// <summary>
        /// 逻辑同solution3578，Solution3578中有两处慢的地方
        /// 1. 找出区别的最大值与最小值，这个可以用稀疏表来优化
        /// 2. 计算区间的和，这个可以用前缀和来优化
        /// 使用上面两处优化再次解一下这个问题
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPartitions(int[] nums, int k)
        {
            throw new NotImplementedException();
        }
    }
}
