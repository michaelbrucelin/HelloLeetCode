using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0023
{
    public class Solution0023 : Interface0023
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode pa = headA, pb = headB;
            bool flaga = true, flagb = true;
            while (pa != null)  // pa != null && pa != null
            {
                if (pa == pb) return pa;
                pa = pa.next; pb = pb.next;
                if (pa == null && flaga) { pa = headB; flaga = false; }
                if (pb == null && flagb) { pb = headA; flagb = false; }
            }

            return null;
        }
    }
}
