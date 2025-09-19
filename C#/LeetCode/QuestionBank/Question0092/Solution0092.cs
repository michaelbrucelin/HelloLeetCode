using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0092
{
    public class Solution0092 : Interface0092
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="head"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right) return head;

            ListNode dummy = new ListNode(-1, head);
            List<ListNode> list = new List<ListNode>();
            ListNode pa, pz, ptr = dummy;
            int idx = 0;
            while (idx < left - 1) { ptr = ptr.next; idx++; }
            pa = ptr; ptr = ptr.next; idx++;
            while (idx <= right) { list.Add(ptr); ptr = ptr.next; idx++; }
            pz = ptr;

            ptr = pa;
            for (int i = list.Count - 1; i >= 0; i--) { ptr.next = list[i]; ptr = ptr.next; }
            ptr.next = pz;

            return dummy.next;
        }
    }
}
