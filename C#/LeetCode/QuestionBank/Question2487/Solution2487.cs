using LeetCode.QuestionBank.Question0116;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2487
{
    public class Solution2487 : Interface2487
    {
        /// <summary>
        /// 栈
        /// 最终的链表单调非增
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveNodes(ListNode head)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = head;
            while (ptr != null)
            {
                stack.Push(ptr); ptr = ptr.next;
            }

            ListNode next = stack.Pop();
            while (stack.Count > 0)
            {
                if ((ptr = stack.Pop()).val >= next.val)
                {
                    ptr.next = next; next = ptr;
                }
            }

            return next;
        }
    }
}
