using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3217
{
    public class Solution3217 : Interface3217
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            HashSet<int> set = [.. nums];
            ListNode dummy = new ListNode(-1) { next = head };
            ListNode p1 = dummy, p2 = dummy;
            while ((p2 = p2.next) != null)
            {
                if (set.Contains(p2.val))
                {
                    p1.next = p2.next;
                }
                else
                {
                    p1 = p2;
                }
            }

            return dummy.next;
        }
    }
}
