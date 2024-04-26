using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0123
{
    public class Solution0123 : Interface0123
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] ReverseBookList(ListNode head)
        {
            if (head == null) return [];
            if (head.next == null) return [head.val];

            List<int> list = new List<int>();
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }

            int[] result = new int[list.Count];
            for (int i = 0; i < list.Count; i++) result[list.Count - i - 1] = list[i];

            return result;
        }
    }
}
