using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0024
{
    public class Solution0024 : Interface0024
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode dummy = new ListNode(); dummy.next = head;
            ListNode ptrPerv = dummy;
            ListNode ptrA = ptrPerv.next;
            ListNode ptrB = ptrA.next;
            while (true)
            {
                ptrPerv.next = ptrB; ptrA.next = ptrB.next; ptrB.next = ptrA;  // 交换

                if (ptrA.next != null && ptrA.next.next != null)
                {
                    ptrPerv = ptrA; ptrA = ptrPerv.next; ptrB = ptrA.next;     // 移动指针
                }
                else break;
            }

            return dummy.next;
        }
    }
}
