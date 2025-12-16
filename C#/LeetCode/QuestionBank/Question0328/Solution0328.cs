using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0328
{
    public class Solution0328 : Interface0328
    {
        /// <summary>
        /// 三指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null) return head;
            ListNode head_odd = head, head_even = head.next;
            ListNode ptr = head.next.next, ptr_odd = head_odd, ptr_even = head_even;
            bool is_odd = true;
            while (ptr != null)
            {
                if (is_odd)
                {
                    ptr_odd.next = ptr; ptr_odd = ptr;
                }
                else
                {
                    ptr_even.next = ptr; ptr_even = ptr;
                }
                ptr = ptr.next;
                is_odd = !is_odd;
            }
            ptr_odd.next = head_even;
            ptr_even.next = null;

            return head_odd;
        }
    }
}
