using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0023
{
    public class Solution0023_2 : Interface0023
    {
        /// <summary>
        /// 优先级队列
        /// 同Solution0023，将插入排序改为优先级队列（最小堆）
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            if (lists.Length == 1) return lists[0];

            PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();
            for (int i = 0; i < lists.Length; i++)
                if (lists[i] != null) queue.Enqueue(lists[i], lists[i].val);

            ListNode dummy = new ListNode();
            ListNode ptr = dummy;
            while (queue.Count > 0)
            {
                if (queue.Count == 1) ptr.next = queue.Dequeue();
                else
                {
                    ListNode node = queue.Dequeue();
                    ptr.next = node; ptr = ptr.next;
                    if ((node = node.next) != null) queue.Enqueue(node, node.val);
                }
            }

            return dummy.next;
        }
    }
}
