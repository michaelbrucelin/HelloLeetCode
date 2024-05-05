using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0136
{
    public class Solution0136_2 : Interface0136
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head == null) return head;
            if (head.val == val) return head.next;
            head.next = DeleteNode(head.next, val);

            return head;
        }
    }
}
