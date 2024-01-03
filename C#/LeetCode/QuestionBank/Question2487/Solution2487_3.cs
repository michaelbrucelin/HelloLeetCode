using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2487
{
    public class Solution2487_3 : Interface2487
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveNodes(ListNode head)
        {
            if (head.next == null) return head;

            ListNode next = RemoveNodes(head.next);
            if (head.val < next.val) return next;

            head.next = next;
            return head;
        }
    }
}
