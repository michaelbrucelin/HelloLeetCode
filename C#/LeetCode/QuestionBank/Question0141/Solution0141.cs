using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0141
{
    public class Solution0141 : Interface0141
    {
        /// <summary>
        /// HashTable
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> buffer = new HashSet<ListNode>();
            ListNode ptr = head;
            while (ptr != null)
            {
                if (buffer.Contains(ptr)) return true;
                buffer.Add(ptr);
                ptr = ptr.next;
            }

            return false;
        }
    }
}
