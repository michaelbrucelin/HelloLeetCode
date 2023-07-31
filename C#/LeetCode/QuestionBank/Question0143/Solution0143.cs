using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0143
{
    public class Solution0143 : Interface0143
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = head, prev = new ListNode(-1), next1, next2, _next1;
            while (ptr != null) { stack.Push(ptr); ptr = ptr.next; }
            next1 = head; next2 = stack.Pop();
            while (next2 != next1 && next2 != next1.next)
            {
                _next1 = next1.next; prev.next = next1; next1.next = next2; prev = next2;
                next1 = _next1; next2 = stack.Pop();
            }
            if (next2 == next1)
            {
                prev.next = next1; next1.next = null;
            }
            else  // next2 == next1.next
            {
                prev.next = next1; next1.next = next2; next2.next = null;
            }
        }

        /// <summary>
        /// 栈 + 双指针
        /// 逻辑与上面的一样，通过上指针，可以实现在栈中只缓存一半的节点，节省一半的内存
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList2(ListNode head)
        {
            if (head.next == null || head.next.next == null) return;

            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode p1 = head, p2 = head.next;
            while (p2.next != null && p2.next.next != null) { p1 = p1.next; p2 = p2.next.next; }
            ListNode ptr = p1.next, prev = new ListNode(-1), next1, next2, _next1;
            while (ptr != null) { stack.Push(ptr); ptr = ptr.next; }
            next1 = head; next2 = stack.Pop();
            while (next2 != next1 && next2 != next1.next)
            {
                _next1 = next1.next; prev.next = next1; next1.next = next2; prev = next2;
                next1 = _next1; next2 = stack.Pop();
            }
            if (next2 == next1)
            {
                prev.next = next1; next1.next = null;
            }
            else  // next2 == next1.next
            {
                prev.next = next1; next1.next = next2; next2.next = null;
            }
        }
    }
}
