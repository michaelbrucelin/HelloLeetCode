using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0202
{
    public class Solution0202 : Interface0202
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthToLast(ListNode head, int k)
        {
            if (k == 1)
            {
                ListNode p = head;
                while (p.next != null) p = p.next;
                return p.val;
            }
            else
            {
                ListNode pfast = head, pslow = head;
                for (int i = 1; i < k; i++) pfast = pfast.next;  // 题目限定k有效，不需要判断指针是否为null
                while (pfast.next != null) { pfast = pfast.next; pslow = pslow.next; }
                return pslow.val;
            }
        }
    }
}
