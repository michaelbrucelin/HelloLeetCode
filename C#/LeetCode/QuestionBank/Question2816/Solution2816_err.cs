using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2816
{
    public class Solution2816_err : Interface2816
    {
        /// <summary>
        /// 模拟
        /// 
        /// 溢出
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DoubleIt(ListNode head)
        {
            int x = 0;
            ListNode ptr = head;
            while (ptr != null) { x = x * 10 + ptr.val; ptr = ptr.next; }
            if ((x <<= 1) == 0) return head;

            // ptr = null;
            while (x > 0) { ptr = new ListNode(x % 10, ptr); x /= 10; }

            return ptr;
        }
    }
}
