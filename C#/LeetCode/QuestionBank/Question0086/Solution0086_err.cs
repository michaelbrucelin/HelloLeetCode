using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0086
{
    public class Solution0086_err : Interface0086
    {
        /// <summary>
        /// 原地交换，双指针
        /// 
        /// 逻辑错误，参考测试用例01，画画图
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null) return head;

            ListNode dummy = new ListNode(0, head);
            ListNode p1 = dummy, p2, t1, t2, t3;
            while (p1 != null)
            {
                while (p1.next != null && p1.next.val < x) p1 = p1.next;
                if (p1.next == null) break;
                p2 = p1.next;
                while (p2.next != null && p2.next.val >= x) p2 = p2.next;
                if (p2.next == null) break;

                // 原地交换
                t1 = p1.next; t2 = p2.next;
                p1.next = t2; p2.next = t1;
                t3 = t1.next; t1.next = t2.next; t2.next = t3;

                p1 = p1.next;
            }

            return dummy.next;
        }
    }
}
