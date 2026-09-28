using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1721
{
    public class Solution1721 : Interface1721
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode pl, pr, ptr = head;
            while (--k > 0) ptr = ptr.next;                             // 题目限定 k <= 链表长度
            pl = ptr; pr = head;
            while (ptr.next != null) { pr = pr.next; ptr = ptr.next; }
            (pl.val, pr.val) = (pr.val, pl.val);

            return head;
        }
    }
}
