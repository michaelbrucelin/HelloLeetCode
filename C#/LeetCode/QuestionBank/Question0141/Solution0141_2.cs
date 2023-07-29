using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0141
{
    public class Solution0141_2 : Interface0141
    {
        /// <summary>
        /// 快慢指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;
            if (head.next == head) return true;

            ListNode slow = head.next, fast = head.next.next;
            while (fast != null)
            {
                if (fast == slow) return true;
                if (fast.next == null) return false;
                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }

        /// <summary>
        /// 快慢指针，添加哑点简化代码
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle2(ListNode head)
        {
            ListNode dummy = new ListNode(-1) { next = head };
            ListNode pfast = dummy, pslow = dummy;
            while (pfast.next != null && pfast.next.next != null)
            {
                pfast = pfast.next.next; pslow = pslow.next;
                if (pfast == pslow) return true;
            }

            return false;
        }
    }
}
