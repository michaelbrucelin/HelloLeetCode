using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0027
{
    public class Solution0027 : Interface0027
    {
        /// <summary>
        /// 栈 + 快慢指针
        /// 快慢指针找到链表的中间节点，栈记录链表前半段的值，然后比较前后两半的值
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return true;

            ListNode dummy = new ListNode() { next = head };
            ListNode p1 = dummy, p2 = dummy;
            Stack<int> stack = new Stack<int>();
            while (p2 != null && p2.next != null)
            {
                p1 = p1.next; p2 = p2.next.next;
                stack.Push(p1.val);
            }
            p1 = p1.next;
            if (p2 == null) stack.Pop();

            while (p1 != null)  // p1 != null && stack.Count > 0
            {
                if (p1.val != stack.Pop()) return false;
                p1 = p1.next;
            }

            return true;
        }
    }
}
