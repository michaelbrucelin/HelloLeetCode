using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0024
{
    public class Solution0024_2 : Interface0024
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            ListNode ptr = head, _head = null, _tail;
            while (ptr != null)
            {
                _tail = ptr.next;
                ptr.next = _head;
                _head = ptr;
                ptr = _tail;
            }

            return _head;
        }
    }
}
