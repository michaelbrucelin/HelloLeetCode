using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0160
{
    public class Solution0160_2 : Interface0160
    {
        /// <summary>
        /// 将第一个链表的尾节点与第二个链表的头节点连接起来
        /// 如果两个链表相交，那么新的链表就有环，而且入换的节点就是连个链表相交的节点
        /// 如果两个链表不相交，那么新的链表就没有环
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            bool flag = true;      // true 第一次到达headA的末端，需要将其与headB接到一起
            ListNode slow = headA, fast = headA, tailA = new ListNode(-1);
            while (fast != null)
            {
                if (fast.next == null)
                {
                    if (flag) { fast.next = headB; tailA = fast; flag = false; } else { tailA.next = null; return null; }
                }
                else if (fast.next.next == null)
                {
                    if (flag) { fast.next.next = headB; tailA = fast.next; flag = false; } else { tailA.next = null; return null; }
                }
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)  // 有环，且相遇
                {
                    slow = headA;
                    while (fast != slow) { slow = slow.next; fast = fast.next; }
                    tailA.next = null;
                    return slow;
                }
            }
            tailA.next = null;

            return null;
        }
    }
}
