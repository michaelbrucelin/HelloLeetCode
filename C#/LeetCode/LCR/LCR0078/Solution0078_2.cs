using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0078
{
    public class Solution0078_2 : Interface0078
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeKLists(lists, 0, lists.Length - 1);

            static ListNode MergeKLists(ListNode[] lists, int left, int right)
            {
                if (left > right) return null;
                if (left == right) return lists[left];

                int mid = left + ((right - left) >> 1);
                ListNode llist = MergeKLists(lists, left, mid);
                ListNode rlist = MergeKLists(lists, mid + 1, right);
                switch ((llist, rlist))
                {
                    case (null, null): return null;
                    case (_, null): return llist;
                    case (null, _): return rlist;
                    default:
                        ListNode dummy = new ListNode(), ptr = dummy, pl = llist, pr = rlist;
                        while (pl != null && pr != null)
                        {
                            if (pl.val <= pr.val) { ptr = ptr.next = pl; pl = pl.next; } else { ptr = ptr.next = pr; pr = pr.next; }
                        }
                        while (pl != null) { ptr = ptr.next = pl; pl = pl.next; }
                        while (pr != null) { ptr = ptr.next = pr; pr = pr.next; }
                        return dummy.next;
                }
            }
        }
    }
}
