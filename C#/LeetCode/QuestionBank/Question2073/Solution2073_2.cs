using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2073
{
    public class Solution2073_2 : Interface2073
    {
        /// <summary>
        /// 数学
        /// 假定第k个人需要买cnt张票
        ///     第k个人耗费k秒
        ///     在其前面的人，买票数量小于cnt的，全买，大于等于cnt的，买cnt张
        ///     在其后面的人，买票数量小于cnt-1的，全买，大于等于cnt-1的，买cnt-1张
        /// </summary>
        /// <param name="tickets"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            int result = 0;
            for (int i = 0; i <= k; i++) result += Math.Min(tickets[k], tickets[i]);
            for (int i = k + 1; i < tickets.Length; i++) result += Math.Min(tickets[k] - 1, tickets[i]);

            return result;
        }
    }
}
