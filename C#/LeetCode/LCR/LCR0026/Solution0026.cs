using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0026
{
    public class Solution0026 : Interface0026
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            List<ListNode> list = [];
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr); ptr = ptr.next; }

            ptr = new ListNode();
            int i, j;
            for (i = 0, j = list.Count - 1; i < j; i++, j--)
            {
                ptr.next = list[i]; ptr = list[i];
                ptr.next = list[j]; ptr = list[j];
            }
            if (i == j) { ptr.next = list[i]; ptr = list[i]; }
            ptr.next = null;
        }
    }
}
