using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0201
{
    public class Solution0201 : Interface0201
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveDuplicateNodes(ListNode head)
        {
            if (head == null || head.next == null) return head;

            HashSet<int> visited = new HashSet<int>();
            ListNode ptr = head, pre = null;
            while (ptr != null)
            {
                if (visited.Contains(ptr.val))
                {
                    pre.next = ptr.next;
                }
                else
                {
                    pre = ptr; visited.Add(ptr.val);
                }
                ptr = ptr.next;
            }

            return head;
        }

        /// <summary>
        /// 遍历
        /// 逻辑与RemoveDuplicateNodes()相同，只是将HashSet改为了位图（long[] set），写着玩的
        /// num使用set[num/63]的第num%63位记录
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RemoveDuplicateNodes2(ListNode head)
        {
            if (head == null || head.next == null) return head;

            List<long> visited = new List<long>();
            ListNode ptr = head, pre = null;
            while (ptr != null)
            {
                int id = ptr.val / 63, offset = ptr.val % 63;
                if (visited.Count < id + 1) for (int i = id + 1 - visited.Count; i > 0; i--) visited.Add(0);
                if (((visited[id] >> offset) & 1) == 1)
                {
                    pre.next = ptr.next;
                }
                else
                {
                    pre = ptr; visited[id] |= 1L << offset;
                }
                ptr = ptr.next;
            }

            return head;
        }
    }
}
