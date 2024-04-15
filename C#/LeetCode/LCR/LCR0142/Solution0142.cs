using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0142
{
    public class Solution0142 : Interface0142
    {
        /// <summary>
        /// 归并
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode TrainningPlan(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode p0 = dummy, p1 = l1, p2 = l2;
            while (p1 != null && p2 != null)
            {
                if (p1.val <= p2.val)
                {
                    p0.next = p1; p0 = p0.next; p1 = p1.next;
                }
                else
                {
                    p0.next = p2; p0 = p0.next; p2 = p2.next;
                }
            }
            p0.next = p1 != null ? p1 : p2;

            return dummy.next;
        }
    }
}
