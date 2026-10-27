using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0078
{
    public class Solution0078 : Interface0078
    {
        /// <summary>
        /// 小顶堆
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            PriorityQueue<ListNode, int> minpq = new PriorityQueue<ListNode, int>();
            foreach (ListNode node in lists) if (node != null) minpq.Enqueue(node, node.val);
            ListNode dummy = new ListNode(), ptr = dummy, list;
            while (minpq.Count > 0)
            {
                list = minpq.Dequeue();
                ptr = ptr.next = list;   // ptr.next = list; ptr = ptr.next;
                list = list.next;
                if (list != null) minpq.Enqueue(list, list.val);
            }

            return dummy.next;
        }
    }
}
