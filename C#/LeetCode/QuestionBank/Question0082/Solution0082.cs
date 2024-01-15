using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0082
{
    public class Solution0082 : Interface0082
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode dummy = new ListNode(int.MinValue, head);
            ListNode p0 = dummy, pl = head, pr;
            while (pl != null)
            {
                if (pl.next == null || pl.val != pl.next.val)
                {
                    p0.next = pl; p0 = pl;
                    pl = pl.next;
                }
                else
                {
                    pr = pl.next.next;
                    while (pr != null && pr.val == pl.val) pr = pr.next;
                    pl = pr;
                }
            }
            p0.next = null;

            return dummy.next;
        }
    }
}
