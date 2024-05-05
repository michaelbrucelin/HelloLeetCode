using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0136
{
    public class Solution0136 : Interface0136
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head == null) return head;
            if (head.val == val) return head.next;

            ListNode p1 = head, p2 = head.next;
            while (p2 != null)
            {
                if (p2.val == val)
                {
                    p1.next = p2.next;
                    break;
                }
                p2 = p2.next; p1 = p1.next;
            }

            return head;
        }
    }
}
