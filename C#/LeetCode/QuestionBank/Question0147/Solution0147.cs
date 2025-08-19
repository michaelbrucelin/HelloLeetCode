using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0147
{
    public class Solution0147 : Interface0147
    {
        /// <summary>
        /// 三指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode dummy = new ListNode(int.MinValue, head);
            ListNode pl, pr = head, temp;
            while (pr != null)
            {
                while (pr.next != null && pr.next.val >= pr.val) pr = pr.next;
                if (pr.next == null) break;
                pl = dummy;
                while (pl.next.val < pr.next.val) pl = pl.next;
                temp = pr.next.next; pr.next.next = pl.next; pl.next = pr.next; pr.next = temp;
            }

            return dummy.next;
        }
    }
}
