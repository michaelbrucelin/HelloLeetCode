using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0052
{
    public class Solution0052_2 : Interface0052
    {
        /// <summary>
        /// 双指针
        /// 1. 双指针分别从头到尾遍历两个链表
        ///     1.1. 如果两个链表的结尾不同，两个链表没有相交，否则相交
        ///     1.2. 可以得出两个链表的节点数目
        /// 2. 如果节点数相等，就两个指针同时向前走，如果不等，长的那个链表先走出ABS(m-n)个节点后，两个指针同时向前走
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode ptrA = headA, ptrB = headB;
            int lenA = 1, lenB = 1;
            while (ptrA.next != null) { lenA++; ptrA = ptrA.next; }
            while (ptrB.next != null) { lenB++; ptrB = ptrB.next; }
            if (ptrA != ptrB) return null;

            ptrA = headA; ptrB = headB;
            if (lenA > lenB)
                for (int i = 0; i < lenA - lenB; i++) ptrA = ptrA.next;
            else if (lenB > lenA)
                for (int i = 0; i < lenB - lenA; i++) ptrB = ptrB.next;
            while (ptrA != ptrB)
            {
                ptrA = ptrA.next; ptrB = ptrB.next;
            }

            return ptrA;
        }
    }
}
