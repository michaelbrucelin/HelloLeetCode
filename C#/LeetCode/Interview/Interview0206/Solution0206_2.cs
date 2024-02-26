using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0206
{
    public class Solution0206_2 : Interface0206
    {
        /// <summary>
        /// 进阶
        /// 由于题目提出了空间复杂度为O(1)的进阶解法，而由于链表无法逆序遍历，显然无法实现
        /// 除非把链表的后半段反转，也就是仍然是O(n)的空间复杂度，只不过借用了自身的的空间
        /// 但是这样做类似于树的Morris遍历，并发场景会有问题。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return true;

            ListNode dummy = new ListNode(-1) { next = head };
            ListNode pslow = dummy, pfast = dummy;
            while (pfast.next != null && pfast.next.next != null)
            {
                pslow = pslow.next; pfast = pfast.next.next;
            }

            // 反转后半段链表
            ListNode _head = ReverseList(pslow.next);
            bool result = true; ListNode p = head, _p = _head;
            while (_p != null)
            {
                if (p.val != _p.val) { result = false; break; }
                p = p.next; _p = _p.next;
            }

            // 恢复后半段链表
            ReverseList(_head);

            return result;
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode pre = null, curr = head, next;
            while (curr != null)
            {
                if (curr.next == null)
                {
                    curr.next = pre; break;
                }
                else
                {
                    next = curr.next; curr.next = pre; pre = curr; curr = next;
                }
            }

            return curr;
        }
    }
}
