using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0140
{
    public class Solution0140 : Interface0140
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public ListNode TrainingPlan(ListNode head, int cnt)
        {
            if (cnt == 1)
            {
                while (head.next != null) head = head.next;
            }
            else  // if (cnt > 1)
            {
                ListNode _head = head;
                while (--cnt > 0) _head = _head.next;
                while (_head.next != null) { _head = _head.next; head = head.next; }
            }

            return head;
        }
    }
}
