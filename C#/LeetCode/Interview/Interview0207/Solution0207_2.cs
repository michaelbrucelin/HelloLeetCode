using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0207
{
    public class Solution0207_2 : Interface0207
    {
        /// <summary>
        /// 固定套路
        /// A -> B
        /// B -> A
        /// 两个遍历找相遇
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode ptrA = headA, ptrB = headB; bool flagA = true, flagB = true;
            while (true)
            {
                if (ptrA == ptrB) return ptrA;
                ptrA = ptrA.next; if (ptrA == null)
                {
                    if (flagA)
                    {
                        ptrA = headB; flagA = false;
                    }
                    else
                    {
                        break;
                    }
                }
                ptrB = ptrB.next; if (ptrB == null)
                {
                    if (flagB)
                    {
                        ptrB = headA; flagB = false;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return null;
        }
    }
}
