using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0025
{
    public class Solution0025 : Interface0025
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> s1 = new Stack<int>(), s2 = new Stack<int>();
            ListNode ptr = l1;
            while (ptr != null) { s1.Push(ptr.val); ptr = ptr.next; }
            ptr = l2;
            while (ptr != null) { s2.Push(ptr.val); ptr = ptr.next; }

            ListNode head = null; ptr = null;
            int i1, i2, carry = 0;
            while (s1.Count > 0 || s2.Count > 0 || carry > 0)
            {
                i1 = s1.Count > 0 ? s1.Pop() : 0;
                i2 = s2.Count > 0 ? s2.Pop() : 0;
                head = new ListNode((i1 + i2 + carry) % 10);
                head.next = ptr;
                ptr = head;
                carry = (i1 + i2 + carry) / 10;
            }

            return head;
        }
    }
}
