using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0208
{
    public class Solution0208 : Interface0208
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> set = [];
            ListNode ptr = head;
            while (ptr != null) if (set.Add(ptr)) ptr = ptr.next; else return ptr;

            return null;
        }
    }
}
