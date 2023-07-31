using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0142
{
    public class Solution0142_2 : Interface0142
    {
        /// <summary>
        /// 快慢指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            ListNode dummy = new ListNode(-1) { next = head };
            ListNode p1 = dummy, p2 = dummy;
            while (p2.next != null && p2.next.next != null)
            {
                p1 = p1.next; p2 = p2.next.next;
                if (p1 == p2)
                {
                    p1 = dummy;
                    while (p1 != p2) { p1 = p1.next; p2 = p2.next; }
                    return p1;
                }
            }

            return null;
        }
    }
}
