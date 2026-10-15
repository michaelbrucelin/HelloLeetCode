using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0208
{
    public class Solution0208_2 : Interface0208
    {
        /// <summary>
        /// 双指针
        /// 经典追及问题
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;

            ListNode p1 = head, p2 = head;
            while (p2.next != null && p2.next.next != null)
            {
                p1 = p1.next; p2 = p2.next.next;
                if (p1 != p2) continue;
                p1 = head;
                while (p1 != p2) { p1 = p1.next; p2 = p2.next; }
                return p1;
            }

            return null;
        }
    }
}
