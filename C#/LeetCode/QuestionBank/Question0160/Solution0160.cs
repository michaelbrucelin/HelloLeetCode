using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0160
{
    public class Solution0160 : Interface0160
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> buffer = new HashSet<ListNode>();
            ListNode ptr = headA;
            while (ptr != null)
            {
                buffer.Add(ptr);
                ptr = ptr.next;
            }
            ptr = headB;
            while (ptr != null)
            {
                if (buffer.Contains(ptr)) return ptr;
                ptr = ptr.next;
            }

            return null;
        }
    }
}
