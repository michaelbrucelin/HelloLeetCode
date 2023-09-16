using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0876
{
    public class Solution0876 : Interface0876
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {
            ListNode p1 = head, p2 = head;
            while (true)
            {
                if (p1.next != null && p1.next.next != null)
                {
                    p1 = p1.next.next; p2 = p2.next;
                }
                else
                {
                    if (p1.next != null) p2 = p2.next;
                    break;
                }
            }

            return p2;
        }
    }
}
