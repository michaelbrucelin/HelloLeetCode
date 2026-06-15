using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2095
{
    public class Solution2095 : Interface2095
    {
        /// <summary>
        /// 快慢指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteMiddle(ListNode head)
        {
            ListNode dummy = new ListNode(-1, head);
            ListNode p1 = dummy, p2 = dummy;
            while (p2.next != null && p2.next.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }
            p1.next = p1.next.next;

            return dummy.next;
        }
    }
}
