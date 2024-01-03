using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2487
{
    public class Solution2487_2 : Interface2487
    {
        /// <summary>
        /// 反转链表 + 遍历链表
        /// 本质上逻辑与Solution2487相同，只是没有借助栈，而是反转链表，操作后再次翻转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveNodes(ListNode head)
        {
            head = ReverseNodes(head);
            ListNode ptr = head;
            while (ptr != null)
            {
                while (ptr.next != null && ptr.next.val < ptr.val) ptr.next = ptr.next.next;
                ptr = ptr.next;
            }

            return ReverseNodes(head);
        }

        private ListNode ReverseNodes(ListNode head)
        {
            ListNode p1 = null, p2 = head, p3;  // p1, p2, p3分别是前一个节点、当前节点、下一个节点
            while (p2 != null)
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }

            return p1;
        }
    }
}
