using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0207
{
    public class Solution0207 : Interface0207
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode node = headA;
            while (node != null) { set.Add(node); node = node.next; }

            node = headB;
            while (node != null)
            {
                if (set.Contains(node)) return node; node = node.next;
            }

            return null;
        }
    }
}
