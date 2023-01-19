using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0206
{
    public class Solution0206 : Interface0206
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            return rec(head).head;
        }

        private (ListNode head, ListNode tail) rec(ListNode node)
        {
            if (node == null) return (null, null);

            var info = rec(node.next);
            if (info.head == null) return (node, node);
            node.next = null;
            info.tail.next = node;

            return (info.head, node);
        }
    }
}
