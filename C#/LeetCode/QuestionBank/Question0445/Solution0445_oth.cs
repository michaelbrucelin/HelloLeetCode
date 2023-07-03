using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0445
{
    public class Solution0445_oth : Interface0445
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int cnt1 = Count(l1), cnt2 = Count(l2);
            if (cnt2 > cnt1)
            {
                int t = cnt1; cnt1 = cnt2; cnt2 = t; ListNode l = l1; l1 = l2; l2 = l;
            }
            ListNode dummy = new ListNode(0);
            ListNode ptr = dummy, ptr1 = l1, ptr2 = l2, ptr0 = dummy; int add = 0;
            for (int i = 0; i < cnt1 - cnt2; i++)
            {
                ptr.next = new ListNode(ptr1.val); ptr = ptr.next; ptr1 = ptr1.next;
                if (ptr.val != 9) ptr0 = ptr;
            }
            for (int i = 0; i < cnt2; i++)
            {
                if ((add = ptr1.val + ptr2.val) < 10)
                {
                    ptr.next = new ListNode(add);
                    if (add < 9) ptr0 = ptr.next;
                }
                else
                {
                    ptr.next = new ListNode(add - 10);
                    ptr0.val++; ptr0 = ptr0.next;
                    while (ptr0 != ptr.next)
                    {
                        ptr0.val = 0; ptr0 = ptr0.next;
                    }
                }
                ptr = ptr.next; ptr1 = ptr1.next; ptr2 = ptr2.next;
            }

            return dummy.val != 0 ? dummy : dummy.next;
        }

        private int Count(ListNode l)
        {
            if (l == null) return 0;

            int count = 0;
            while (l != null)
            {
                count++; l = l.next;
            }

            return count;
        }
    }
}
