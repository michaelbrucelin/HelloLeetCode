using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0714
{
    public class Solution0714 : Interface0714
    {
        /// <summary>
        /// 贪心
        /// 1. 手续费就相当于成本价提高了，与没有手续费是一回事，没有手续费就相当于手续费为0
        /// 2. 如果价格比前一天的价格高，更新高的价格
        ///    如果价格比前一天的价格低，前1天就可以卖出了（当然亏本不能卖，相当于没买）
        ///        当前价格就是新的采购价格
        /// 本质上就是找出价格走势的每一个单调递增区间，可以借助双指针技巧
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices, int fee)
        {
            int result = 0;


            return result;
        }
    }
}
