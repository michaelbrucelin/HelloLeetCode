using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0142
{
    public class Solution0142 : Interface0142
    {
        /// <summary>
        /// HashTable
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode ptr = head;
            while (ptr != null)
            {
                if (set.Contains(ptr)) return ptr;
                set.Add(ptr); ptr = ptr.next;
            }

            return null;
        }
    }
}
