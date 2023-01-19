using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0234
{
    public class Solution0234_2 : Interface0234
    {
        /// <summary>
        /// 使用栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head.next == null) return true;
            if (head.next.next == null) return head.val == head.next.val;

            Stack<int> stack = new Stack<int>();
            int cnt = 0; ListNode ptr = head;
            while (ptr != null) { stack.Push(ptr.val); ptr = ptr.next; cnt++; }

            ptr = head;
            int i = -1; cnt >>= 1;
            while (++i <= cnt) if (ptr.val != stack.Pop()) return false; else ptr = ptr.next;

            return true;
        }

        /// <summary>
        /// 同IsPalindrome()，但是使用双指针可以将空间复杂度减半
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome2(ListNode head)
        {
            if (head.next == null) return true;
            if (head.next.next == null) return head.val == head.next.val;

            Stack<int> stack = new Stack<int>(); stack.Push(head.val);
            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null) { slow = slow.next; stack.Push(slow.val); fast = fast.next.next; }

            if (fast != null) slow = slow.next;  // 链表节点是偶数个
            while (slow != null) if (slow.val != stack.Pop()) return false; else slow = slow.next;

            return true;
        }
    }
}
