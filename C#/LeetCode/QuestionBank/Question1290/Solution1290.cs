using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1290
{
    public class Solution1290 : Interface1290
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int GetDecimalValue(ListNode head)
        {
            int result = 0;
            ListNode ptr = head;
            while (ptr != null)
            {
                result = (result << 1) | ptr.val;
                ptr = ptr.next;
            }

            return result;
        }
    }
}
