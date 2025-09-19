using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0092
{
    public class Solution0092_2 : Interface0092
    {
        /// <summary>
        /// 原地
        /// </summary>
        /// <param name="head"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) return head;

            ListNode dummy = new ListNode(-1, head);
            ListNode pa, pl, ptr = dummy, pprev, pnext;
            int idx = 0;
            while (idx < left - 1) { ptr = ptr.next; idx++; }
            pa = ptr; pl = ptr.next;
            pprev = pl; ptr = pprev.next; pnext = ptr.next; idx = left + 1;
            while (idx < right)
            {
                pnext = ptr.next;
                ptr.next = pprev;
                pprev = ptr; ptr = pnext; pnext = ptr.next;
                idx++;
            }
            ptr.next = pprev; pa.next = ptr; pl.next = pnext;

            return dummy.next;
        }
    }
}
