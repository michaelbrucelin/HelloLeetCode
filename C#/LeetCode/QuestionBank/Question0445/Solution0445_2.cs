using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0445
{
    public class Solution0445_2 : Interface0445
    {
        /// <summary>
        /// 栈
        /// 由于栈的FILO特性，本质上仍然是翻转链表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<ListNode> s1 = ToStack(l1), s2 = ToStack(l2);
            return Add(s1, s2);
        }

        private ListNode Add(Stack<ListNode> s1, Stack<ListNode> s2)
        {
            ListNode p1 = null, p2, ps1, ps2; int extra = 0;
            while (s1.Count > 0 && s2.Count > 0)
            {
                ps1 = s1.Pop(); ps2 = s2.Pop();
                p2 = new ListNode((ps1.val + ps2.val + extra) % 10);
                extra = (ps1.val + ps2.val + extra) / 10;
                p2.next = p1; p1 = p2;
            }
            while (s1.Count > 0)
            {
                ps1 = s1.Pop();
                p2 = new ListNode((ps1.val + extra) % 10);
                extra = (ps1.val + extra) / 10;
                p2.next = p1; p1 = p2;
            }
            while (s2.Count > 0)
            {
                ps2 = s2.Pop();
                p2 = new ListNode((ps2.val + extra) % 10);
                extra = (ps2.val + extra) / 10;
                p2.next = p1; p1 = p2;
            }
            if (extra != 0)
            {
                p2 = new ListNode(extra); p2.next = p1; p1 = p2;
            }

            return p1;
        }

        private Stack<ListNode> ToStack(ListNode l)
        {
            if (l == null) return new Stack<ListNode>();

            Stack<ListNode> stack = new Stack<ListNode>();
            while (l != null)
            {
                stack.Push(l); l = l.next;
            }

            return stack;
        }
    }
}
