using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0206
{
    public class Solution0206_2 : Interface0206
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode prev = head, curr = head.next, next;
            while (curr != null)
            {
                next = curr.next; curr.next = prev; prev = curr; curr = next;
            }
            head.next = null;

            return prev;
        }
    }
}
