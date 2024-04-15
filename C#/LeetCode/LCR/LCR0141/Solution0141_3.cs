using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0141
{
    public class Solution0141_3 : Interface0141
    {
        /// <summary>
        /// 迭代
        /// 改变输入的栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode TrainningPlan(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode _head = null, ptr = head, next;
            while (ptr != null)
            {
                next = ptr.next; ptr.next = _head; _head = ptr; ptr = next;
            }

            return _head;
        }
    }
}
