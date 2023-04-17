using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0052
{
    public class Solution0052_off_2 : Interface0052
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode ptrA = headA, ptrB = headB;
            while (ptrA != ptrB)
            {
                ptrA = ptrA == null ? headB : ptrA.next;
                ptrB = ptrB == null ? headA : ptrB.next;
            }

            return ptrA;
        }
    }
}
