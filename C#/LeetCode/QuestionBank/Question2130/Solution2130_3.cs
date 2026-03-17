using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2130
{
    public class Solution2130_3 : Interface2130
    {
        /// <summary>
        /// 反转链表
        /// 反转后半段链表，最省内存，生产环境谨慎使用，不可并发
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int PairSum(ListNode head)
        {
            ListNode dummy = new ListNode() { next = head };
            ListNode p1 = dummy, p2 = dummy;
            while (p2.next != null) { p1 = p1.next; p2 = p2.next.next; }

            // 反转后半段链表
            ListNode head2 = p1.next;
            // head2 = p2 = reverse(head2).Item1;
            head2 = p2 = reverse(head2);

            int result = 0;
            p1 = head;
            while (p2 != null)
            {
                result = Math.Max(result, p1.val + p2.val);
                p1 = p1.next; p2 = p2.next;
            }

            // 恢复链表
            reverse(head2);

            return result;

            static ListNode reverse(ListNode node)
            {
                if (node.next == null) return node;

                ListNode _head = reverse(node.next);
                node.next.next = node;
                node.next = null;
                return _head;
            }

            /*
            static (ListNode, ListNode) reverse(ListNode node)
            {
                if (node.next == null) return (node, node);

                var info = reverse(node.next);
                info.Item2.next = node;
                node.next = null;
                return (info.Item1, node);
            }
            */
        }

        /// <summary>
        /// 逻辑同PairSum()，将反转列表的部分改为迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int PairSum2(ListNode head)
        {
            ListNode dummy = new ListNode() { next = head };
            ListNode p1 = dummy, p2 = dummy;
            while (p2.next != null) { p1 = p1.next; p2 = p2.next.next; }

            // 反转后半段链表
            ListNode head2 = p1.next;
            head2 = p2 = reverse(head2);

            int result = 0;
            p1 = head;
            while (p2 != null)
            {
                result = Math.Max(result, p1.val + p2.val);
                p1 = p1.next; p2 = p2.next;
            }

            // 恢复链表
            reverse(head2);

            return result;

            static ListNode reverse(ListNode node)
            {
                ListNode prev = null, curr = node, next;
                while (curr != null)
                {
                    next = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = next;
                }

                return prev;
            }
        }
    }
}
