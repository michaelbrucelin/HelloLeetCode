using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0142
{
    public class Solution0142_2 : Interface0142
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode TrainningPlan(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val <= l2.val)
            {
                l1.next = TrainningPlan(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = TrainningPlan(l1, l2.next);
                return l2;
            }
        }
    }
}
