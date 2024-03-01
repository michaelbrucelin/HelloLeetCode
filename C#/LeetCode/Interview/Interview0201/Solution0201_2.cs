using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0201
{
    public class Solution0201_2 : Interface0201
    {
        /// <summary>
        /// 暴力查找
        /// 不仅没有TLE，而且没想到暴力查找竟然就是官解的进阶解法... ...
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveDuplicateNodes(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode ptr = head, pl, pr;
            while (ptr != null)
            {
                pl = ptr; pr = ptr.next;
                while (pr != null)
                {
                    if (pr.val == ptr.val)
                        pl.next = pr.next;
                    else
                        pl = pr;
                    pr = pr.next;
                }
                ptr = ptr.next;
            }

            return head;
        }
    }
}
