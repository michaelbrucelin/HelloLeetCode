using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0234
{
    public class Solution0234_4 : Interface0234
    {
        /// <summary>
        /// 递归
        /// 有一种为了递归而递归的味道，只是联系一下，感觉没有现实意义
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            ListNode left = head;
            return rec(head, ref left);
        }

        private bool rec(ListNode right, ref ListNode left)
        {
            if (right == null) return true;

            if (!rec(right.next, ref left)) return false;
            if (right.val != left.val) return false;
            left = left.next;

            return true;
        }
    }
}
