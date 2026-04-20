using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0022
{
    public class Solution0022 : Interface0022
    {
        /// <summary>
        /// 模板题
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;

            ListNode p1 = head, p2 = head;
            while ((p2 = p2.next) != null && (p2 = p2.next) != null)
            {
                if ((p1 = p1.next) == p2) goto CYCLE;
            }
            return null;

        CYCLE:;
            p1 = head;
            while (p1 != p2) { p1 = p1.next; p2 = p2.next; }
            return p1;
        }
    }
}
