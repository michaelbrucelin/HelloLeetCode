using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2816
{
    public class Solution2816 : Interface2816
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DoubleIt(ListNode head)
        {
            List<int> digits = [];
            ListNode ptr = head;
            while (ptr != null) { digits.Add(ptr.val); ptr = ptr.next; }
            if (digits.Count == 1 && digits[0] == 0) return head;

            int carry = 0, cnt = digits.Count;
            for (int i = cnt - 1, j; i >= 0; i--)
            {
                j = (digits[i] << 1) + carry;
                digits[i] = j % 10;
                carry = j / 10;
            }
            if (carry > 0) digits.Insert(0, carry);

            ListNode dummy = new ListNode();
            ptr = dummy;
            cnt = digits.Count;
            for (int i = 0; i < cnt; i++)
            {
                ptr.next = new ListNode(digits[i]);
                ptr = ptr.next;
            }

            return dummy.next;
        }
    }
}
