﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0021
{
    public class Solution0021 : Interface0021
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return null;
            ListNode dummy = new ListNode();
            ListNode ptr = dummy, ptr1 = list1, ptr2 = list2;

            while (ptr1 != null && ptr2 != null)
            {
                if (ptr1.val <= ptr2.val)
                {
                    ptr.next = ptr1; ptr = ptr.next; ptr1 = ptr1.next;
                }
                else
                {
                    ptr.next = ptr2; ptr = ptr.next; ptr2 = ptr2.next;
                }
            }
            ptr.next = ptr1 == null ? ptr2 : ptr1;

            return dummy.next;
        }
    }
}
