using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0052
{
    public class Solution0052 : Interface0052
    {
        /// <summary>
        /// Hash表
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode ptr = headA;
            while (ptr != null)
            {
                set.Add(ptr); ptr = ptr.next;
            }
            ptr = headB;
            while (ptr != null)
            {
                if (set.Contains(ptr)) return ptr;
                ptr = ptr.next;
            }

            return null;
        }

        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            Stack<ListNode> stackA = new Stack<ListNode>();
            Stack<ListNode> stackB = new Stack<ListNode>();
            ListNode ptr = headA;
            while (ptr != null)
            {
                stackA.Push(ptr); ptr = ptr.next;
            }
            ptr = headB;
            while (ptr != null)
            {
                stackB.Push(ptr); ptr = ptr.next;
            }

            if (stackA.Peek() != stackB.Peek()) return null;
            ListNode result = stackA.Pop(); stackB.Pop();
            while (stackA.Count > 0 && stackB.Count > 0 && stackA.Peek() == stackB.Peek())
            {
                result = stackA.Pop(); stackB.Pop();
            }

            return result;
        }
    }
}
