using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0024
{
    public class Solution0024 : Interface0024
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            return rec(null, head);
        }

        private ListNode rec(ListNode head, ListNode tail)
        {
            if (tail == null) return head;
            ListNode _tail = tail.next;
            tail.next = head;
            return rec(tail, _tail);
        }
    }
}
