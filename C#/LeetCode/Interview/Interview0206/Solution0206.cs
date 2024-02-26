using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0206
{
    public class Solution0206 : Interface0206
    {
        /// <summary>
        /// 链表转数组
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            List<int> list = new List<int>();
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }
            for (int i = 0, j = list.Count - 1; i < j; i++, j--)
            {
                if (list[i] != list[j]) return false;
            }

            return true;
        }
    }
}
