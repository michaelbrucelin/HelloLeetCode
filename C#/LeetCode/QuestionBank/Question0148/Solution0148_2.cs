using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0148
{
    public class Solution0148_2 : Interface0148
    {
        /// <summary>
        /// 自底向上归并
        /// 直接完成进阶的要求，即O(1)的空间复杂度 + O(nlogn)的时间复杂度
        /// 快排与堆排都需要O(1)的时间复杂度取获取元素，链表无法达到，而归并排序只依赖前后关系，所以可以把归并排序拿到链表中使用
        /// 
        /// 难度不大，但是细节比较多，易错
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode ptr = head;
            int total = 0;
            while (ptr != null) { total++; ptr = ptr.next; }

            ListNode dummy = new ListNode(int.MinValue, head);
            ListNode phead, _phead, p1, p2;
            int span = 1, cnt;
            while (span < total)
            {
                phead = dummy; _phead = phead.next;
                while (_phead != null)
                {
                    p1 = _phead;
                    // 寻找第1段链表
                    ptr = p1; cnt = 1;
                    while (cnt < span && ptr != null) { cnt++; ptr = ptr.next; }
                    if (ptr != null) { p2 = ptr.next; ptr.next = null; } else p2 = null;
                    // 寻找第2段链表
                    ptr = p2; cnt = 1;
                    while (cnt < span && ptr != null) { cnt++; ptr = ptr.next; }
                    if (ptr != null) { _phead = ptr.next; ptr.next = null; } else _phead = null;
                    // 归并两段链表
                    while (p1 != null && p2 != null) switch (p1.val - p2.val)
                        {
                            case <= 0: phead.next = p1; p1 = p1.next; phead = phead.next; break;
                            default: phead.next = p2; p2 = p2.next; phead = phead.next; break;
                        }
                    while (p1 != null) { phead.next = p1; p1 = p1.next; phead = phead.next; }
                    while (p2 != null) { phead.next = p2; p2 = p2.next; phead = phead.next; }
                    phead.next = null;
                }
                span <<= 1;
            }

            return dummy.next;
        }
    }
}
