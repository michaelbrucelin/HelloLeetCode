using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0061
{
    public class Solution0061 : Interface0061
    {
        /// <summary>
        /// 重构链表
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return head;

            int cnt = 1;
            ListNode tail = head;
            while (tail.next != null) { cnt++; tail = tail.next; }

            k %= cnt;
            if (k == 0) return head;

            tail.next = head;
            ListNode ptr = head;
            for (int i = 1; i < cnt - k; i++) ptr = ptr.next;
            ListNode _head = ptr.next;
            ptr.next = null;

            return _head;
        }
    }
}
