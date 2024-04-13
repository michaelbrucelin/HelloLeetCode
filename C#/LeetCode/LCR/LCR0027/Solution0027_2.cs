using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0027
{
    public class Solution0027_2 : Interface0027
    {
        /// <summary>
        /// 反转链表 + 快慢指针
        /// 题目进阶要求： O(n) 时间复杂度和 O(1) 空间复杂度解决此题
        /// 没想到其他办法，只想到了将链表的后半段反转，判断完后，再给反转回来
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return true;

            ListNode dummy = new ListNode() { next = head };
            ListNode p1 = dummy, p2 = dummy, pmid;
            while (p2 != null && p2.next != null)
            {
                p1 = p1.next; p2 = p2.next.next;
            }
            pmid = p1;

            p1 = head; p2 = ReverseList(pmid.next);
            while (p2 != null)
            {
                if (p1.val != p2.val)
                {
                    ReverseList(pmid.next);
                    return false;
                }
                p1 = p1.next; p2 = p2.next;
            }

            return true;
        }

        private ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            ListNode ptr = head, _head = null, _tail;
            while (ptr != null)
            {
                _tail = ptr.next;
                ptr.next = _head;
                _head = ptr;
                ptr = _tail;
            }

            return _head;
        }
    }
}
