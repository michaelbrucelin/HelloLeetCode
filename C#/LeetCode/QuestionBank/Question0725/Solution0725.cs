using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0725
{
    public class Solution0725 : Interface0725
    {
        /// <summary>
        /// 两轮遍历
        /// 其实可以使用快慢指针的思想，使用k个指针加速，不做了，没必要
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            int cnt = 0;
            ListNode ptr = head;
            while (ptr != null) { cnt++; ptr = ptr.next; }

            ListNode[] result = new ListNode[k];
            int p = 0; ptr = head;
            if (k >= cnt)
            {
                while (ptr != null) { result[p] = ptr; ptr = ptr.next; result[p++].next = null; }
            }
            else
            {
                int cnt1 = cnt / k, cnt2 = cnt % k; ListNode prev;
                while (cnt2-- > 0)
                {
                    result[p++] = ptr;
                    for (int i = 0; i < cnt1; i++) ptr = ptr.next;
                    prev = ptr; ptr = ptr.next; prev.next = null;
                }
                while (p < k)
                {
                    result[p++] = ptr;
                    for (int i = 1; i < cnt1; i++) ptr = ptr.next;
                    prev = ptr; ptr = ptr.next; prev.next = null;
                }
            }

            return result;
        }
    }
}
