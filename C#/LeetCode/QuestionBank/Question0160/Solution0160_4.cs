using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0160
{
    public class Solution0160_4 : Interface0160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode ptr1 = headA, ptr2 = headB;
            while (ptr1 != ptr2)
            {
                if (ptr1 == null) ptr1 = headB; else ptr1 = ptr1.next;
                if (ptr2 == null) ptr2 = headA; else ptr2 = ptr2.next;
            }

            return ptr1;
        }
    }
}
