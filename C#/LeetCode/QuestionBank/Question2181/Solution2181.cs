using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2181
{
    public class Solution2181 : Interface2181
    {
        public ListNode MergeNodes(ListNode head)
        {
            ListNode dummy = new ListNode();
            ListNode prev = dummy, ptr = head;  // 节点数 >= 3
            int val = 0;
            while (ptr != null)
            {
                if (ptr.val != 0)
                {
                    val += ptr.val;
                }
                else
                {
                    prev.next = new ListNode(val); prev = prev.next; val = 0;
                }
                ptr = ptr.next;
            }

            return dummy.next.next;
        }
    }
}
