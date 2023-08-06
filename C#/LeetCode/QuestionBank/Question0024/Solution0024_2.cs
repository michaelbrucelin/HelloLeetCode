using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0024
{
    public class Solution0024_2 : Interface0024
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode head_next = head.next;
            head.next = SwapPairs(head_next.next);
            head_next.next = head;

            return head_next;
        }
    }
}
