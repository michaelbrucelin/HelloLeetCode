using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2074
{
    public class Solution2074 : Interface2074
    {
        /// <summary>
        /// 列表模拟
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseEvenLengthGroups(ListNode head)
        {
            List<ListNode> list = [];
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr); ptr = ptr.next; }
            int p = 0, q, inc = 1, cnt = list.Count; ListNode tmp;
            while (p < cnt)
            {
                q = Math.Min(p + inc, cnt);
                if (((q - p) & 1) == 0) for (int i = p, j = q - 1; i < j; i++, j--)
                    {
                        tmp = list[i]; list[i] = list[j]; list[j] = tmp;
                    }
                p += inc++;
            }

            list.Add(null);
            for (int i = 0; i < cnt; i++) list[i].next = list[i + 1];
            return head;
        }
    }
}
