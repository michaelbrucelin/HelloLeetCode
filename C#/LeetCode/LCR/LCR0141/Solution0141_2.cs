using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0141
{
    public class Solution0141_2 : Interface0141
    {
        /// <summary>
        /// 递归
        /// 改变输入的栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode TrainningPlan(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode _head = TrainningPlan(head.next);
            head.next.next = head;
            head.next = null;

            return _head;
        }
    }
}
