using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2240
{
    public class Solution2240_err : Interface2240
    {
        /// <summary>
        /// 数学
        /// 线性规划，就是ax+by<=c, x>=0, y>=0的整数解的个数
        /// 
        /// 错误的，参考测试用例04
        /// 因为需要单独分析ax+by=c的整数解，如果分析还不如枚举了，暂时不解决了
        /// </summary>
        /// <param name="total"></param>
        /// <param name="cost1"></param>
        /// <param name="cost2"></param>
        /// <returns></returns>
        public long WaysToBuyPensPencils(int total, int cost1, int cost2)
        {
            long start = 1, end = total / cost2 + 1, cnt = total / cost1 + 1;
            return ((start + end) * cnt) >> 1;
        }
    }
}
