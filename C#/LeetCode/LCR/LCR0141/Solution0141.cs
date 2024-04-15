using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0141
{
    public class Solution0141 : Interface0141
    {
        /// <summary>
        /// 栈
        /// 不改变输入的栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode TrainningPlan(ListNode head)
        {
            if (head == null || head.next == null) return head;

            Stack<int> stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.val); head = head.next;
            }

            ListNode dummy = new ListNode();
            ListNode ptr = dummy;
            while (stack.Count > 0)
            {
                ptr.next = new ListNode(stack.Pop());
                ptr = ptr.next;
            }

            return dummy.next;
        }
    }
}
